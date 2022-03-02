import { useEffect, useState } from "react";

import { Button, Col, Form, Popconfirm, Row, Space, Table } from "antd";
import {
  PlusOutlined,
  DeleteOutlined,
  EditOutlined,
  DollarOutlined,
} from "@ant-design/icons";

import Column from "antd/lib/table/Column";

import EditEntregador from "./edit-entregador";
import api from "../services/api";
import ValorEntregaEntregador from "./valor-entrega-entregador";
import ModalRelatorio from "./modal-relatorio";

export interface documento {
  imagemDocumento: any /*UploadFile<unknown>*/;
}

export interface telefone {
  ddd: number;
  numeroTelefone: string;
  id: number;
  dataCriacao: string;
  ultimaAtualizacao: string;
}

export interface endereco {
  cep: number;
  estado: string;
  cidade: string;
  logradouro: string;
  numero: string;
  complemento: string;
  entregadorId: number;
  id: number;
  dataCriacao: string;
  ultimaAtualizacao: string;
}

export interface entregador {
  key: number;
  nome: string;
  sobrenome: string;
  cpf: string;
  cnh: string;
  endereco: endereco;
  documentos: documento[];
  telefones: telefone[];
  id: number;
  dataCriacao: string;
  ultimaAtualizacao: string;
}

export default function Entregador() {
  const [form] = Form.useForm();
  const [formValoresEmpresas] = Form.useForm();
  const [visible, setVisible] = useState(false);
  const [modalVisible, setModalVisible] = useState(false);
  const [relatorioVisible, setRelatorioVisible] = useState(false);
  const [entregadores, setEntregadores] = useState<entregador[]>([]);
  const [entregadoresSelecionados, setEntregadoresSelecionados] = useState<
    entregador[]
  >([]);
  const [entregador, setEntregador] = useState<entregador>({
    key: 0,
    nome: "",
    sobrenome: "",
    cpf: "",
    cnh: "",
    endereco: {
      cep: 0,
      estado: "",
      cidade: "",
      logradouro: "",
      numero: "",
      complemento: "",
      entregadorId: 0,
      id: 0,
      dataCriacao: "",
      ultimaAtualizacao: "",
    },
    documentos: [],
    telefones: [],
    id: 0,
    dataCriacao: "",
    ultimaAtualizacao: "",
  });

  useEffect(() => {
    api.get("api/Entregadores").then(({ data }) => {
      setEntregadores(data);
    });
  }, []);

  const rowSelection = {
    onChange: (selectedRowKeys: React.Key[], selectedRows: entregador[]) => {
      setEntregadoresSelecionados(selectedRows);
    },
  };

  function handleNew() {
    form.resetFields();
    showDrawer();
  }

  function handleEdit(entregador: entregador) {
    form.setFieldsValue(entregador);
    showDrawer();
  }

  function handleDelete(entregador: entregador) {
    api.delete("api/Entregadores/" + entregador.id).then(function () {
      setEntregadores(
        entregadores.filter((entreg: entregador) => entreg.id !== entregador.id)
      );
    });
  }

  function handleFinish(entregador: entregador) {
    if (entregador.id == null || entregador.id === undefined)
      api
        .post("api/Entregadores", entregador)
        .then(function (response) {
          setEntregadores(entregadores.concat(response.data));
        })
        .catch(function (error) {
          console.log(error);
        });
    else
      api
        .put("api/Entregadores", entregador)
        .then(function (response) {
          let updatedEntregadores = entregadores.map((entreg: entregador) => {
            if (response.data.id === entreg.id) entreg = response.data;

            return entreg;
          });
          setEntregadores(updatedEntregadores);
        })
        .catch(function (error) {
          console.log(error);
        });
  }

  function handleValorEntregas(entregador: entregador) {
    formValoresEmpresas.resetFields();
    setEntregador(entregador);
    setModalVisible(true);
  }

  function gerarExcel() {
    setRelatorioVisible(true);
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

  entregadores.map(
    (entregador: entregador) => (entregador.key = entregador.id)
  );

  return (
    <>
      <Row justify="end" gutter={8}>
        <Col>
          {entregadoresSelecionados.length > 0 && (
            <Button
              type="primary"
              onClick={gerarExcel}
              icon={<PlusOutlined />}
              style={{ marginBottom: "20px" }}
            >
              Relatórios
            </Button>
          )}
        </Col>
        <Col>
          <Button
            type="primary"
            onClick={handleNew}
            icon={<PlusOutlined />}
            style={{ marginBottom: "20px" }}
          >
            Novo Entregador
          </Button>
        </Col>
      </Row>
      <Table
        dataSource={entregadores}
        rowSelection={{
          type: "checkbox",
          ...rowSelection,
        }}
      >
        <Column
          title="Nome Completo"
          key="nome"
          render={(text, record: entregador) => (
            <p>{record.nome + " " + record.sobrenome}</p>
          )}
        />
        <Column title="Cpf" dataIndex="cpf" key="cpf" />
        <Column title="Cnh" dataIndex="cnh" key="cnh" />
        <Column
          title="Endereço"
          key="endereco"
          render={(text, record: entregador) => (
            <p>{record.endereco?.cidade}</p>
          )}
        />
        <Column
          title="Telefone"
          key="telefone"
          render={(text, record: entregador) => (
            <p>
              {record.telefones.length > 0
                ? record.telefones[0]?.ddd +
                  " " +
                  record.telefones[0]?.numeroTelefone
                : null}
            </p>
          )}
        />
        <Column
          title="Ações"
          key="acoes"
          render={(text, record: entregador) => (
            <Space size="middle">
              <Button
                type="primary"
                icon={<EditOutlined />}
                onClick={() => handleEdit(record)}
              />
              <Popconfirm
                placement="topRight"
                title={"Tem certeza que deseja deletar essa empresa?"}
                onConfirm={() => handleDelete(record)}
                okText="Sim"
                cancelText="Não"
              >
                <Button type="primary" icon={<DeleteOutlined />} danger />
              </Popconfirm>
              <Button
                type="default"
                icon={<DollarOutlined />}
                onClick={() => handleValorEntregas(record)}
              />
            </Space>
          )}
        />
      </Table>
      <EditEntregador
        form={form}
        handleFinish={handleFinish}
        onClose={onClose}
        onOk={onOk}
        setVisible={setVisible}
        showDrawer={showDrawer}
        visible={visible}
      />
      {formValoresEmpresas && (
        <ValorEntregaEntregador
          entregador={entregador}
          modalVisible={modalVisible}
          setModelVisible={setModalVisible}
          form={formValoresEmpresas}
        />
      )}
      <ModalRelatorio
        entregadoresSelecionados={entregadoresSelecionados}
        modalVisible={relatorioVisible}
        setModelVisible={setRelatorioVisible}
      />
    </>
  );
}
