import { Flex, Row, Typography } from "antd";
import { ArrowLeftOutlined } from "@ant-design/icons";
import { useNavigate, useParams } from "react-router-dom";
import CreateTaskDrawer from "../../features/tasks/components/CreateTaksDrawer";
import { useGetUserTasksQuery } from "../../features/users/api/user-api.slice";
import TaskCard from "../../features/tasks/components/TaskCard";
import { Task } from "../../features/tasks/types/task.type";
const { Title } = Typography;

function UserDetailPage() {
  const navigate = useNavigate();

  const { id } = useParams();

  if (!id) {
    throw new Error("No se ha proporcionado un id de usuario.");
  }

  const {data: tasks, isLoading} = useGetUserTasksQuery(id);

  return (
    <Flex
      vertical
      align="center"
      style={{ paddingInline: 50, paddingBlock: 20 }}
    >
      <Flex
        gap={20}
        wrap
        align="center"
        justify="space-between"
        style={{ width: "100%", paddingInline: 15, marginBottom: 10 }}
      >
        <Title>Tareas</Title>
        <Flex vertical gap={10}>
          <Typography.Text type="secondary">
            <b>Tareas del usuario:</b> {tasks?.length || 0}
          </Typography.Text>
          <Typography.Text type="success" style={{ marginLeft: 10, cursor: "pointer" }} onClick={() => navigate("/")}>
            {<ArrowLeftOutlined />} Volver a usuarios
          </Typography.Text>
        </Flex>
        <CreateTaskDrawer />
      </Flex>
      <Row gutter={12} justify="center">
        {tasks?.map((task: Task) => (
          <TaskCard key={task.id} task={task} isLoading={isLoading} />
        ))}
      </Row>
    </Flex>
  );
}

export default UserDetailPage;
