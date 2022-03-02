import {
  Button,
  Col,
  Drawer,
  Form,
  FormInstance,
  Input,
  Row,
  Space,
} from "antd";
import { PlusOutlined, MinusCircleOutlined } from "@ant-design/icons";

interface props {
  visible: boolean;
  showDrawer: () => void;
  setVisible: (value: boolean) => void;
  handleFinish: (value: any) => void;
  onClose: () => void;
  onOk: () => void;
  form: FormInstance<any>;
}

export default function EditEntregador(props: props) {
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
          <Form.Item hidden name={["id"]} label="ID">
            <Input placeholder="ID" defaultValue={0} />
          </Form.Item>
          <Row gutter={12}>
            <Col span={12}>
              <Form.Item name={["nome"]} label="Nome">
                <Input />
              </Form.Item>
            </Col>
            <Col span={12}>
              <Form.Item name={["sobrenome"]} label="Sobrenome">
                <Input />
              </Form.Item>
            </Col>
          </Row>
          <Row gutter={12}>
            <Col span={12}>
              <Form.Item name={["cpf"]} label="Cpf">
                <Input />
              </Form.Item>
            </Col>
            <Col span={12}>
              <Form.Item name={["cnh"]} label="Cnh">
                <Input />
              </Form.Item>
            </Col>
          </Row>
          <Row gutter={12}>
            <Col span={8}>
              <Form.Item name={["endereco", "cep"]} label="Cep">
                <Input />
              </Form.Item>
            </Col>
            <Col span={4}>
              <Form.Item name={["endereco", "estado"]} label="Estado">
                <Input />
              </Form.Item>
            </Col>
            <Col span={12}>
              <Form.Item name={["endereco", "cidade"]} label="Cidade">
                <Input />
              </Form.Item>
            </Col>
          </Row>
          <Row gutter={12}>
            <Col span={12}>
              <Form.Item name={["endereco", "logradouro"]} label="Logradouro">
                <Input />
              </Form.Item>
            </Col>
            <Col span={5}>
              <Form.Item name={["endereco", "numero"]} label="Numero">
                <Input />
              </Form.Item>
            </Col>
            <Col span={7}>
              <Form.Item name={["endereco", "complemento"]} label="Complemento">
                <Input />
              </Form.Item>
            </Col>
          </Row>
          <Form.List name="telefones">
            {(fields, { add, remove }) => (
              <>
                {fields.map(({ key, name, ...restField }) => (
                  <Row key={key} gutter={12}>
                    <Col span={4}>
                      <Form.Item
                        {...restField}
                        name={[name, "ddd"]}
                        label="DDD"
                        rules={[{ required: true, message: "DDD" }]}
                      >
                        <Input placeholder="Insira o DD" />
                      </Form.Item>
                    </Col>
                    <Col span={8}>
                      <Form.Item
                        {...restField}
                        name={[name, "numeroTelefone"]}
                        label="Telefone"
                        rules={[
                          { required: true, message: "Numero de telefone" },
                        ]}
                      >
                        <Input placeholder="Insira o número de telefone" />
                      </Form.Item>
                    </Col>
                    <Col span={2}>
                      <MinusCircleOutlined onClick={() => remove(name)} />
                    </Col>
                  </Row>
                ))}
                <Form.Item>
                  <Button
                    type="dashed"
                    onClick={() => add()}
                    block
                    icon={<PlusOutlined />}
                  >
                    Adicionar Telefone
                  </Button>
                </Form.Item>
              </>
            )}
          </Form.List>
        </Form>
      </Drawer>
    </>
  );
}
