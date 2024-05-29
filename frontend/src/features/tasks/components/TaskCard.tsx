import { Badge, Card, Col, Descriptions } from "antd";
import { Task } from "../types/task.type";

function TaskCard({ task, isLoading }: { task: Task; isLoading: boolean }) {
  return (
    <Col span={18} style={{ marginBottom: 30 }}>
      
      <Badge.Ribbon text="Tarea" color="blue">
      <Card bordered={false} loading={isLoading}>
        <Descriptions size="small" layout="vertical">
          <Descriptions.Item label="Título">{task.title}</Descriptions.Item>
          <Descriptions.Item label="Descripción">{task.description}</Descriptions.Item>
          <Descriptions.Item label="Etiquetas">{task.tags.join(",")}</Descriptions.Item>
          <Descriptions.Item label="Fecha de expiración">{new Date(task.expirationDate).toLocaleDateString()}</Descriptions.Item>
          <Descriptions.Item label="¿Finalizada?">{task.finished ? "Sí" : "No"}</Descriptions.Item>
          <Descriptions.Item label="Usuario">{`${task.user.name} ${task.user.surname}`}</Descriptions.Item>
          <Descriptions.Item label="Prioridad">{task.priority.name}</Descriptions.Item>
        </Descriptions>
      </Card>
      </Badge.Ribbon>
    </Col>
  );
}

export default TaskCard;
