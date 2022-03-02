import React from "react";
import ReactDOM from "react-dom";
import App from "./App";

import { ConfigProvider } from "antd";
import ptBr from "antd/lib/locale/pt_BR";

import "antd/dist/antd.css";

ReactDOM.render(
  <ConfigProvider locale={ptBr}>
    <App />
  </ConfigProvider>,
  document.getElementById("root")
);
