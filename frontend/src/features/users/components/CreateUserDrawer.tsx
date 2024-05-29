import React, { useState } from "react";
import { UserAddOutlined } from "@ant-design/icons";
import { Button, Col, Drawer, Form, Input, message, Row, Space } from "antd";
import { useCreateUserMutation } from "../api/user-api.slice";
import { User } from "../types/user.type";

const App: React.FC = () => {
  const [open, setOpen] = useState(false);

  const [form] = Form.useForm();
  const [createUser, { isLoading }] = useCreateUserMutation();

  const showDrawer = () => {
    setOpen(true);
  };

  const onClose = () => {
    setOpen(false);
  };

  const onFinish = async (values: User) => {
    try {
      await createUser(values).unwrap();
      message.success("Usuario creado correctamente.", 4);
      form.resetFields();
      onClose();
    } catch (error) {
      const errorApi = error as { data: { Errors: string } };
      message.error(errorApi.data.Errors, 5);
    }
  };

  return (
    <>
      <Button
        onClick={showDrawer}
        size="large"
        icon={<UserAddOutlined />}
        type="text"
      >
        Crear usuario
      </Button>
      <Drawer
        title="Crear un nuevo usuario"
        width={720}
        onClose={onClose}
        open={open}
        styles={{
          body: {
            paddingBottom: 80,
          },
        }}
        extra={
          <Space>
            <Button onClick={onClose}>Cancelar</Button>
            <Button
              onClick={() => form.submit()}
              type="primary"
              loading={isLoading}
            >
              Guardar
            </Button>
          </Space>
        }
      >
        <Form layout="vertical" form={form} onFinish={onFinish}>
          <Row gutter={16}>
            <Col span={12}>
              <Form.Item
                name="name"
                label="Nombre"
                rules={[
                  { required: true, message: "Por favor ingrese su nombre" },
                ]}
              >
                <Input placeholder="Jose" />
              </Form.Item>
            </Col>
            <Col span={12}>
              <Form.Item
                name="surname"
                label="Apellido"
                rules={[
                  { required: true, message: "Debe ingresar su apellido." },
                ]}
              >
                <Input placeholder="Dubón" />
              </Form.Item>
            </Col>
          </Row>
          <Row gutter={16}>
            <Col span={12}>
              <Form.Item
                name="email"
                label="Correo electrónico"
                rules={[
                  {
                    required: true,
                    message: "Debe ingresar un correo electrónico",
                  },
                  {
                    type: "email",
                    message: "Debe ingresar un correo electrónico válido",
                  },
                ]}
              >
                <Input placeholder="jose.dubon@gmail.com" />
              </Form.Item>
            </Col>
            <Col span={12}>
              <Form.Item
                name="phone"
                label="Teléfono"
                rules={[
                  {
                    required: true,
                    message: "Debe ingresar su número de teléfono.",
                  },
                  {
                    pattern: /^[0-9\b]+$/,
                    message: "Sin espacios ni guiones, solo números.",
                  },
                  {
                    min: 8,
                    message: "Mínimo 8 dígitos.",
                  },
                ]}
              >
                <Input placeholder="99887766" />
              </Form.Item>
            </Col>
          </Row>
        </Form>
      </Drawer>
    </>
  );
};

export default App;
