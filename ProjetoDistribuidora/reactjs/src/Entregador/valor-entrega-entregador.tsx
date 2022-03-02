import { Button, Form, FormInstance, Input, Modal, Select, Space } from "antd";
import { MinusCircleOutlined, PlusOutlined } from "@ant-design/icons";

import { entregador } from "./entregador";
import { useEffect, useState } from "react";
import { empresaContrante } from "../EmpresaContratante/empresa-contratante";
import api from "../services/api";

interface props {
  modalVisible: boolean;
  setModelVisible: (value: boolean) => void;
  entregador: entregador;
  form: FormInstance<any>;
}

interface valorEntregadorEmpresa {
  entregador: entregador;
  empresaContratante: empresaContrante;
  valorEntrega: number;
  id: number;
}

export default function ValorEntregaEntregador(props: props) {
  const [empresasContratantes, setEmpresasConstratantes] = useState<
    empresaContrante[]
  >([]);
  const [valorEmpresas, setValorEmpresas] =
    useState<valorEntregadorEmpresa[]>();

  useEffect(() => {
    api
      .get(
        "api/ValoresEntregadorEmpresa/FindByEntregador?entregadorId=" +
          props.entregador.id
      )
      .then(({ data }) => {
        props.form.setFieldsValue({ valorEmpresas: data });
        setValorEmpresas(data);
      });

    api.get("api/EmpresasContratantes").then(({ data }) => {
      setEmpresasConstratantes(data);
    });
  }, [ props.entregador, props.form, props.modalVisible]);

  function handleOk() {
    props.form.submit();
    props.setModelVisible(false);
  }

  function handleCancel() {
    props.setModelVisible(false);
  }

  function onFinish(valoresEntrega: any) {
    valorEmpresas?.forEach((valor) => {
      api.delete("api/ValoresEntregadorEmpresa/" + valor.id);
    });

    valoresEntrega.valorEmpresas?.forEach((valor: any) => {
      api.post("api/ValoresEntregadorEmpresa/", {
        entregador: { id: props.entregador.id },
        empresaContratante: { id: valor.empresaContratante.id },
        valorEntrega: valor.valorEntrega,
      });
    });
  }

  return (
    <Modal
      title="Preço de entrega por empresa"
      visible={props.modalVisible}
      onOk={handleOk}
      onCancel={handleCancel}
    >
      <Form
        name="valorEntregadorEmpresas"
        onFinish={onFinish}
        autoComplete="off"
        form={props.form}
      >
        <Form.List name="valorEmpresas">
          {(fields, { add, remove }) => (
            <>
              {fields.map(({ key, name, ...restField }) => (
                <Space
                  key={key}
                  style={{ display: "flex", marginBottom: 8 }}
                  align="baseline"
                >
                  <Form.Item
                    {...restField}
                    name={[name, "entregador", "id"]}
                    hidden
                  >
                    <Input placeholder="Preço por entrega" />
                  </Form.Item>
                  <Form.Item
                    {...restField}
                    name={[name, "empresaContratante", "id"]}
                    rules={[
                      {
                        required: true,
                        message: "É necessário selecionar uma empresa",
                      },
                    ]}
                  >
                    <Select
                      showSearch
                      placeholder="Select a person"
                      optionFilterProp="children"
                      filterOption={(input: any, option: any) =>
                        option.children
                          .toLowerCase()
                          .indexOf(input.toLowerCase()) >= 0
                      }
                    >
                      {empresasContratantes.map((empresa: empresaContrante) => (
                        <Select.Option key={empresa.id} value={empresa.id}>
                          {empresa.razaoSocial}
                        </Select.Option>
                      ))}
                    </Select>
                  </Form.Item>
                  <Form.Item
                    {...restField}
                    name={[name, "valorEntrega"]}
                    rules={[
                      { required: true, message: "Insira o preço por entrega" },
                    ]}
                  >
                    <Input placeholder="Preço por entrega" />
                  </Form.Item>
                  <MinusCircleOutlined
                    onClick={() => {
                      remove(name);
                    }}
                  />
                </Space>
              ))}
              <Form.Item>
                <Button
                  type="dashed"
                  onClick={() => add()}
                  block
                  icon={<PlusOutlined />}
                >
                  Adicionar Valor por Empresa
                </Button>
              </Form.Item>
            </>
          )}
        </Form.List>
      </Form>
    </Modal>
  );
}
