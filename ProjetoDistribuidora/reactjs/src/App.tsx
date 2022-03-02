import { Layout, Menu } from "antd";
import {
  DesktopOutlined,
  FileOutlined,
  TeamOutlined,
} from "@ant-design/icons";

import { useState } from "react";
import "./App.css";
import EmpresaContrante from "./EmpresaContratante/empresa-contratante";
import Entregador from "./Entregador/entregador";
import Entrega from "./Entrega/entrega";

const { Header, Content, Footer, Sider } = Layout;

export default function App() {
  const [collapsed, setCollapsed] = useState(false);
  const [selectedMenu, setSelectedMenu] = useState("1");

  function onSelect(props: any){
    setSelectedMenu(props.key);
  }

  return (
    <Layout style={{ minHeight: "100vh" }}>
      <Sider collapsible collapsed={collapsed} onCollapse={setCollapsed}>
        <div className="logo" />
        <Menu theme="dark" defaultSelectedKeys={["1"]} onSelect={onSelect} mode="inline">
          <Menu.Item key="1" icon={<TeamOutlined />}>
            Entregadores
          </Menu.Item>
          <Menu.Item key="2" icon={<DesktopOutlined />}>
            Empresas Contrat.
          </Menu.Item>
          <Menu.Item key="3" icon={<FileOutlined />}>
            Entregas
          </Menu.Item>
         {/* <Menu.Item key="4s icon={<UserOutlined />}>
            Usuarios
  </Menu.Item>*/}
        </Menu>
      </Sider>
      <Layout className="site-layout">
        <Header className="site-layout-background" style={{ padding: 0, textAlign: "center", fontSize: "32px"}}>
          <div style={{  }}>SER LOGÍSTICA</div>
        </Header>
        <Content style={{ margin: "10px 16px" }}>
          <div
            className="site-layout-background"
            style={{ padding: 24, minHeight: 360 }}
          >
            {selectedMenu === "1" && (<Entregador />)}
            {selectedMenu === "2" && (<EmpresaContrante />)}
            {selectedMenu === "3" && (<Entrega />)}
          </div>
        </Content>
        <Footer style={{ textAlign: "center" }}>
          Produced and Distributed by Copatti©  
        </Footer>
      </Layout>
    </Layout>
  );
}
