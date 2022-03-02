import { useState } from "react";
import { Modal, Upload } from "antd";
import { UploadFile } from "antd/lib/upload/interface";
import { entregador, documento } from "./entregador";

interface props {
  modalVisible: boolean;
  setModelVisible: (value: boolean) => void;
  entregador: entregador;
  updateEntregadores: (value: entregador) => void;
}

export default function Documents(props: props) {
  const [fileList, setFileList] = useState<UploadFile<unknown>[]>([]);

  const onChange = (props: any) => {
    setFileList(props.fileList);
  };

  const onPreview = async (file: any) => {
    let src = file.url;
    if (!src) {
      src = new Promise((resolve, reject) => {
        const reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = () => resolve(reader.result);
        reader.onerror = (error) => reject(error);
      });
    }
    const image = new Image();
    image.src = src;
    const imgWindow = window.open(src);
    imgWindow?.document.write(image.outerHTML);
  };

  function handleOk() {
    let documentos: documento[] = fileList.map((file) => ({
      imagemDocumento: file,
    }));

    props.entregador.documentos = documentos;
    props.updateEntregadores(props.entregador);

    props.setModelVisible(false);
  }

  function handleCancel() {
    props.setModelVisible(false);
  }

  return (
    <Modal
      title="Documentos"
      visible={props.modalVisible}
      onOk={handleOk}
      onCancel={handleCancel}
    >
      <Upload
        name="file"
        accept=".jpg, .jpeg, .png"
        beforeUpload={() => {
          return false;
        }}
        action="https://www.mocky.io/v2/5cc8019d300000980a055e76"
        listType="picture-card"
        fileList={fileList}
        onChange={onChange}
        onPreview={onPreview}
      >
        {fileList.length < 5 && "+ Upload"}
      </Upload>
    </Modal>
  );
}
