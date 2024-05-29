import { useState } from "react";
import { UserAddOutlined } from "@ant-design/icons";
import {
  Button,
  Col,
  DatePicker,
  Drawer,
  Form,
  Input,
  message,
  Row,
  Select,
  Space,
} from "antd";
import { useCreateTaskMutation } from "../api/task-api.slice";
import { TaskCreate } from "../types/task.type";
import { useGetAllPrioritiesQuery } from "../../priorities/api/priority-api.slice";
import { useGetUserByIdQuery, usersApi } from "../../users/api/user-api.slice";
import { useParams } from "react-router-dom";
import { useDispatch } from "react-redux";
const { Option } = Select;

function CreateTaskDrawer() {
  const [open, setOpen] = useState(false);

  const [form] = Form.useForm();

  const { data: priorities, isLoading: prioritiesLoading } =
    useGetAllPrioritiesQuery();

  const { id } = useParams();

  if (!id) {
    throw new Error("No se ha proporcionado un id de usuario.");
  }

  const { data: user } = useGetUserByIdQuery(id);
  const [createTask, { isLoading }] = useCreateTaskMutation();

  const showDrawer = () => {
    setOpen(true);
  };

  const onClose = () => {
    setOpen(false);
  };

  const dispatch = useDispatch();

  const onFinish = async (values: TaskCreate) => {
    try {
      values.userId = id;
      await createTask(values).unwrap();
      dispatch(usersApi.util.invalidateTags([{ type: "User", id: "TASKS" }]));
      message.success("Tarea creada correctamente.", 4);
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
        Crear Tarea
      </Button>
      <Drawer
        title="Crear una nueva tarea"
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
                name="title"
                label="Título"
                rules={[
                  { required: true, message: "Debe ingresar un título." },
                ]}
              >
                <Input placeholder="Completar curso de Kubernetes" />
              </Form.Item>
            </Col>
            <Col span={12}>
              <Form.Item
                name="priorityId"
                label="Prioridad"
                rules={[
                  {
                    required: true,
                    message: "Debe seleccionar una prioridad.",
                  },
                ]}
              >
                <Select
                  placeholder="Seleccione una prioridad"
                  loading={prioritiesLoading}
                >
                  {priorities?.map((priority) => (
                    <Option key={priority.id} value={priority.id}>
                      {priority.name}
                    </Option>
                  ))}
                </Select>
              </Form.Item>
            </Col>
          </Row>
          <Row gutter={16}>
            <Col span={24}>
              <Form.Item
                name="description"
                label="Descripción"
                rules={[
                  {
                    required: true,
                    message: "Debe ingresar una descripción.",
                  },
                ]}
              >
                <Input.TextArea
                  rows={4}
                  placeholder="Completar el curso en un 90%"
                />
              </Form.Item>
            </Col>
          </Row>
          <Row gutter={16}>
            <Col span={12}>
              <Form.Item name="userId" label="Se asignará a">
                <Input
                  value={user?.id}
                  disabled
                  defaultValue={`${user?.name} ${user?.surname}`}
                />
              </Form.Item>
            </Col>
            <Col span={12}>
              <Form.Item
                name="expirationDate"
                label="Fecha de expiración"
                rules={[
                  { required: true, message: "Debe ingresar una fecha." },
                ]}
              >
                <DatePicker
                  style={{ width: "100%" }}
                  getPopupContainer={(trigger) => trigger.parentElement!}
                />
              </Form.Item>
            </Col>
          </Row>
          <Row gutter={16}>
            <Col span={24}>
              <Form.Item
                name="tags"
                label="Etiquetas"
                rules={[
                  {
                    required: true,
                    message: "Debe ingresar al menos una etiqueta.",
                  },
                ]}
              >
                <Select mode="tags" placeholder="Escriba y presione enter" />
              </Form.Item>
            </Col>
          </Row>
        </Form>
      </Drawer>
    </>
  );
}

export default CreateTaskDrawer;
