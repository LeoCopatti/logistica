import { Checkbox, Col, DatePicker, Divider, Modal, Row } from "antd";
import { AxiosRequestConfig } from "axios";
import moment from "moment";
import { useState } from "react";
import { entregador } from "./entregador";
import api from "../services/api";

const { RangePicker } = DatePicker;
const CheckboxGroup = Checkbox.Group;

export interface props {
  modalVisible: boolean;
  setModelVisible: (value: boolean) => void;
  entregadoresSelecionados: entregador[];
}

const plainOptions = ["Totalizadores", "Resumido", "Detalhado"];
const defaultCheckedList = ["Totalizadores"];

const monthFormat = "YYYY/MM";
const today: Date = new Date();
const parameters = {
  EntregadoresId: [0],
  PeriodoInicial: moment(
    today.getFullYear() + "/" + today.getMonth(),
    monthFormat
  ),
  PeriodoFinal: moment(
    today.getFullYear() + "/" + (today.getMonth() + 1),
    monthFormat
  ),
  GeraTotalizadores: true,
  GeraResumido: false,
  GeraDetalhado: false,
};

export default function ModalRelatorio(props: props) {
  const [checkedList, setCheckedList] = useState(defaultCheckedList);
  const [confirmLoading, setConfirmLoading] = useState(false);

  const onChangeCheckbox = (list: any) => {
    setCheckedList(list);

    parameters.GeraDetalhado = false;
    parameters.GeraResumido = false;
    parameters.GeraTotalizadores = false;

    list.map(function (opt: string) {
      if (opt === "Totalizadores") parameters.GeraTotalizadores = true;
      if (opt === "Resumido") parameters.GeraResumido = true;
      if (opt === "Detalhado") parameters.GeraDetalhado = true;

      return opt;
    });
  };

  function onChangeDates(dates: any, dateStrings: any) {
    parameters.PeriodoInicial = dates[0];
    parameters.PeriodoFinal = dates[1];
  }

  function handleOk() {
    setConfirmLoading(true);
    parameters.EntregadoresId = props.entregadoresSelecionados.map(function (
      entregador
    ) {
      return entregador.id;
    });
    const options: AxiosRequestConfig<any> = {
      method: "POST",
      responseType: "blob",
      url: "api/Excel",
      data: parameters,
    };

    api
      .request(options)
      .then(function (response) {
        const url = window.URL.createObjectURL(new Blob([response.data]));
        const link = document.createElement("a");
        link.href = url;
        link.setAttribute("download", "file.xlsx"); //or any other extension
        document.body.appendChild(link);
        link.click();
        setConfirmLoading(false);
      })
      .catch(function (error) {
        console.log(error);
        setConfirmLoading(false);
      });
  }

  function handleCancel() {
    props.setModelVisible(false);
  }

  return (
    <Modal
      title="Preço de entrega por empresa"
      visible={props.modalVisible}
      confirmLoading={confirmLoading}
      onOk={handleOk}
      onCancel={handleCancel}
    >
      <Row>
        <Col>
          <CheckboxGroup
            options={plainOptions}
            value={checkedList}
            onChange={onChangeCheckbox}
          />
        </Col>
      </Row>
      <Divider />
      <RangePicker
        picker="month"
        defaultValue={[
          moment(today.getFullYear() + "/" + today.getMonth(), monthFormat),
          moment(
            today.getFullYear() + "/" + (today.getMonth() + 1),
            monthFormat
          ),
        ]}
        format={monthFormat}
        onChange={onChangeDates}
      />
    </Modal>
  );
}
