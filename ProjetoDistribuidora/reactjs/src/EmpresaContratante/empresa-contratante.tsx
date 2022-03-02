import { Button, Col, Form, Popconfirm, Row, Space, Table } from "antd";
import { EditOutlined, DeleteOutlined } from "@ant-design/icons";

import { PlusOutlined } from "@ant-design/icons";
import { useEffect, useState } from "react";
import NovaEmpresaContratante from "./nova-empresa-contratante";
import api from "../services/api";

export interface empresaContrante {
  razaoSocial: string;
  cnpj: string;
  valorBaseEntrega: number;
  id: number;
  key: number;
  dataCriacao: string;
  ultimaAtualizacao: string;
}

export default function EmpresaContrante() {
  const [visible, setVisible] = useState(false);
  const [form] = Form.useForm();
  const [empresasContratantes, setEmpresasConstratantes] = useState<empresaContrante[]>([]);

  const columns = [
    {
      title: "Razão Social",
      dataIndex: "razaoSocial",
      key: "razaoSocial",
    },
    {
      title: "Cnpj",
      dataIndex: "cnpj",
      key: "cnpj",
    },
    {
      title: "Valor Base",
      render: (payload: empresaContrante) => (getValor(payload.valorBaseEntrega)),
      key: "valorBaseEntrega",
    },
    {
      title: "Action",
      key: "action",
      width: "10%",
      render: (payload: empresaContrante) => (
        <Space size="middle">
          <Button
            type="primary"
            icon={<EditOutlined />}
            onClick={() => handleEdit(payload)}
          />
          <Popconfirm
            placement="topRight"
            title={"Tem certeza que deseja deletar essa empresa?"}
            onConfirm={() => handleDelete(payload)}
            okText="Sim"
            cancelText="Não"
          >
            <Button type="primary" icon={<DeleteOutlined />} danger />
          </Popconfirm>
        </Space>
      ),
    },
  ];

  useEffect(() => {
    api.get("api/EmpresasContratantes").then(({ data }) => {
      setEmpresasConstratantes(data);
    });
  }, []);

  function handleNew() {
    form.resetFields();
    showDrawer();
  }

  function handleEdit(empresaContratante: empresaContrante) {
    form.setFieldsValue(empresaContratante);
    showDrawer();
  }

  function handleDelete(empresaContratante: empresaContrante) {
    api
      .delete("api/EmpresasContratantes/" + empresaContratante.id)
      .then(function () {
        setEmpresasConstratantes(
          empresasContratantes.filter(
            (empresa: empresaContrante) => empresa.id !== empresaContratante.id
          )
        );
      });
  }

  function handleFinish(empresaContratante: empresaContrante) {
    if (empresaContratante.id === null || empresaContratante.id === undefined)
      api
        .post("api/EmpresasContratantes", empresaContratante)
        .then(function (response) {
          setEmpresasConstratantes(empresasContratantes.concat(response.data));
        })
        .catch(function (error) {
          console.log(error);
        });
    else
      api
        .put("api/EmpresasContratantes", empresaContratante)
        .then(function (response) {
          let updatedEmpresas = empresasContratantes.map(
            (empresa: empresaContrante) => {
              if (empresa.id === response.data.id) empresa = response.data;

              return empresa;
            }
          );
          setEmpresasConstratantes(updatedEmpresas);
        })
        .catch(function (error) {
          console.log(error);
        });
  }

  function showDrawer() {
    setVisible(true);
  }

  function onClose() {
    setVisible(false);
  }

  function onOk() {
    form.submit();
    setVisible(false);
  }

  const getValor = (valor: number): string => {
    const formatter = new Intl.NumberFormat('en-US', {
      minimumFractionDigits: 2,
      maximumFractionDigits: 2,
    });

    return "R$" + formatter.format(valor).toString()
  }

  empresasContratantes.map(
    (empresa: empresaContrante) => (empresa.key = empresa.id)
  );

  return (
    <>
      <Row justify="end">
        <Col>
          <Button
            type="primary"
            onClick={handleNew}
            icon={<PlusOutlined />}
            style={{ marginBottom: "20px" }}
          >
            Nova Empresa Contratante
          </Button>
        </Col>
      </Row>
      <Table dataSource={empresasContratantes} columns={columns} />
      <NovaEmpresaContratante
        showDrawer={showDrawer}
        form={form}
        handleFinish={handleFinish}
        onClose={onClose}
        onOk={onOk}
        setVisible={setVisible}
        visible={visible}
      />
    </>
  );
}
