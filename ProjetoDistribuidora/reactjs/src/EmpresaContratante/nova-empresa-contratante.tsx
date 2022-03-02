import { Button, Drawer, Form, FormInstance, Input, Space } from "antd";

interface props {
  visible: boolean;
  showDrawer: () => void;
  setVisible: (value: boolean) => void;
  handleFinish: (value: any) => void;
  onClose: () => void;
  onOk: () => void;
  form: FormInstance<any>;
}

export default function NovaEmpresaContratante(props: props) {
  return (
    <>
      <Drawer
        title="Adicione uma nova empresa"
        width={720}
        onClose={props.onClose}
        visible={props.visible}
        bodyStyle={{ paddingBottom: 80 }}
        extra={
          <Space>
            <Button onClick={props.onClose}>Cancelar</Button>
            <Button onClick={props.onOk} type="primary" htmlType="submit">
              Confirmar
            </Button>
          </Space>
        }
      >
        <Form form={props.form} layout="vertical" onFinish={props.handleFinish}>
          <Form.Item hidden name={["id"]} label="Razão Social">
            <Input placeholder="ID" />
          </Form.Item>
          <Form.Item name={["razaoSocial"]} label="Razão Social">
            <Input placeholder="Insira a Razão social da Empresa Contratante" />
          </Form.Item>
          <Form.Item name={["cnpj"]} label="Cnpj">
            <Input placeholder="Insira o CNPJ da Empresa Contratante" />
          </Form.Item>
          <Form.Item name={["valorBaseEntrega"]} label="Valor Base de Entregas">
            <Input placeholder="Insira o valor base de cada entrega" />
          </Form.Item>
        </Form>
      </Drawer>
    </>
  );
}
