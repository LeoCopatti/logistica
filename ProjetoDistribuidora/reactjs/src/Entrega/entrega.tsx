import {
  Select,
  Table,
  Form,
  Input,
  DatePicker,
  Row,
  Col,
  Button,
  Popconfirm,
  InputNumber,
} from "antd";
import Column from "antd/lib/table/Column";
import { useEffect, useState } from "react";

import { DeleteOutlined } from "@ant-design/icons";

import { empresaContrante } from "../EmpresaContratante/empresa-contratante";
import { entregador } from "../Entregador/entregador";
import api from "../services/api";

export interface entrega {
  dataEntrega: string;
  entregador: entregador;
  empresaContratante: empresaContrante;
  valorEntrega: number;
  valorEntregador: number;
  key: number;
  id: number;
}

export default function Entrega() {
  const [form] = Form.useForm();
  const [entregas, setEntregas] = useState<entrega[]>([]);
  const [empresasContratantes, setEmpresasConstratantes] = useState<
    empresaContrante[]
  >([]);
  const [entregadores, setEntregadores] = useState<entregador[]>([]);
  const [empresaContratanteSelecionada, setEmpresaContratanteSelecionada] =
    useState<number>();
  const [entregadorSelecionado, setEntregadorSelecionado] = useState<number>();

  useEffect(() => {
    api.get("api/Entregas").then(({ data }) => {
      setEntregas(data);
    });

    api.get("api/EmpresasContratantes").then(({ data }) => {
      setEmpresasConstratantes(data);
    });

    api.get("api/Entregadores").then(({ data }) => {
      setEntregadores(data);
    });
  }, []);

  useEffect(() => {
    if (
      empresaContratanteSelecionada != null &&
      entregadorSelecionado != null
    ) {
      api
        .get("api/ValoresEntregadorEmpresa/FindByEntregadorEmpresa", {
          params: {
            entregadorId: entregadorSelecionado,
            empresaId: empresaContratanteSelecionada,
          },
        })
        .then(({ data }) => {
          form.setFieldsValue({ valorEntregador: data.valorEntrega ?? empresasContratantes.find(x => x.id === empresaContratanteSelecionada)?.valorBaseEntrega });
        });
    }
  }, [empresaContratanteSelecionada, entregadorSelecionado, form, empresasContratantes]);

  function handleDelete(entrega: entrega) {
    api.delete("api/Entregas/" + entrega.id).then(function () {
      setEntregas(
        entregas.filter((entreg: entrega) => entreg.id !== entrega.id)
      );
    });
  }

  function handleFinish(entrega: entrega) {
    api
      .post("api/Entregas", entrega)
      .then(function (response) {
        setEntregas(entregas.concat(response.data));
      })
      .catch(function (error) {
        console.log(error);
      });
  }

  function onChangeEmpresaContratante(data: any) {
    setEmpresaContratanteSelecionada(data);
  }

  function onChangeEntregador(data: any) {
    setEntregadorSelecionado(data);
  }

  const getFullDate = (date: string): string => {
    const dateAndTime = date.split("T");

    return dateAndTime[0].split("-").reverse().join("/");
  };

  const getValor = (valor: number): string => {
    const formatter = new Intl.NumberFormat("en-US", {
      minimumFractionDigits: 2,
      maximumFractionDigits: 2,
    });

    return "R$" + formatter.format(valor).toString();
  };

  entregas.map((entrega: entrega) => (entrega.key = entrega.id));

  return (
    <>
      <Form layout="vertical" labelAlign="left" onFinish={handleFinish} form={form}>
        <Row gutter={12} style={{ alignItems: "flex-end" }}>
          <Col span={6}>
            <Form.Item
              name={["empresaContratante", "id"]}
              label="Empresa Contratante"
              rules={[
                {
                  required: true,
                  message: "É necessário selecionar uma empresa",
                },
              ]}
            >
              <Select
                showSearch
                optionFilterProp="children"
                onChange={onChangeEmpresaContratante}
                filterOption={(input: any, option: any) =>
                  option.children.toLowerCase().indexOf(input.toLowerCase()) >=
                  0
                }
              >
                {empresasContratantes.map((empresa: empresaContrante) => (
                  <Select.Option key={empresa.id} value={empresa.id}>
                    {empresa.razaoSocial}
                  </Select.Option>
                ))}
              </Select>
            </Form.Item>
          </Col>
          <Col span={6}>
            <Form.Item
              name={["entregador", "id"]}
              label="Entregador"
              rules={[
                {
                  required: true,
                  message: "É necessário selecionar um entregador",
                },
              ]}
            >
              <Select
                showSearch
                optionFilterProp="children"
                onChange={onChangeEntregador}
                filterOption={(input: any, option: any) =>
                  option.children.toLowerCase().indexOf(input.toLowerCase()) >=
                  0
                }
              >
                {entregadores.map((entregador: entregador) => (
                  <Select.Option key={entregador.id} value={entregador.id}>
                    {entregador.nome + " " + entregador.sobrenome}
                  </Select.Option>
                ))}
              </Select>
            </Form.Item>
          </Col>
          <Col span={3}>
            <Form.Item label="Valor para Entregador" name={"valorEntregador"}>
              <InputNumber prefix="R$" controls={false} style={{ width: '100%' }}/>
            </Form.Item>
          </Col>
          <Col span={3}>
            <Form.Item label="Valor de entrega" name={"valorEntrega"}>
              <InputNumber prefix="R$" controls={false} style={{ width: '100%' }}/>
            </Form.Item>
          </Col>
          <Col span={3}>
            <Form.Item label="Data de entrega" name={"dataEntrega"}>
              <DatePicker format={"DD/MM/YYYY"} />
            </Form.Item>
          </Col>
          <Col span={3} style={{ marginBottom: "25px" }}>
            <Button
              style={{ margin: "5px 0 0 0" }}
              type="primary"
              htmlType="submit"
            >
              Adicionar Entrega
            </Button>
          </Col>
        </Row>
      </Form>
      <Table dataSource={entregas}>
        <Column
          title="Entregador"
          key="entregador"
          render={(text, record: entrega) => (
            <p>
              {record?.entregador?.nome + " " + record?.entregador?.sobrenome}
            </p>
          )}
        />
        <Column
          title="Empresa Contratante"
          key="empresaContratante"
          render={(text, record: entrega) => (
            <p>{record?.empresaContratante?.razaoSocial}</p>
          )}
        />
        <Column
          title="Valor Entregador"
          key="valorEntregador"
          render={(record: entrega) => getValor(record.valorEntregador)}
        />
        <Column
          title="Valor Entrega"
          key="valorEntrega"
          render={(record: entrega) => getValor(record.valorEntrega)}
        />
        <Column
          title="Data de entrega"
          key="dataEntrega"
          render={(record: entrega) => getFullDate(record.dataEntrega)}
        />
        <Column
          key="acoes"
          render={(text, record: entrega) => (
            <Popconfirm
              placement="topRight"
              title={"Tem certeza que deseja deletar essa entrega?"}
              onConfirm={() => handleDelete(record)}
              okText="Sim"
              cancelText="Não"
            >
              <Button type="primary" icon={<DeleteOutlined />} danger />
            </Popconfirm>
          )}
        />
      </Table>
    </>
  );
}
