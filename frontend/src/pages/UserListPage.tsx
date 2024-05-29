import { Flex, Row, Typography } from "antd";
import UserCard from "../features/users/components/UserCard";
const { Title } = Typography;

import { useGetAllUsersQuery } from "../features/users/api/user-api.slice";
import { User } from "../features/users/types/user.type";

import CreateUserDrawer from "../features/users/components/CreateUserDrawer";

function UserListPage() {
  const { data: users, isLoading, error } = useGetAllUsersQuery();

  if (isLoading) {
    return (
      <Flex
        style={{ minHeight: "100vh" }}
        vertical
        align="center"
        justify="center"
      >
        <Title type="secondary">Cargando...</Title>
      </Flex>
    );
  }

  if (error) {
    return (
      <Flex
        style={{ minHeight: "100vh" }}
        vertical
        align="center"
        justify="center"
      >
        <Title type="danger">¡Ha ocurrido un error! :(</Title>
      </Flex>
    );
  }

  return (
    <Flex vertical align="center" style={{paddingInline: 50, paddingBlock: 20}}>
      <Flex wrap gap={20} align="center" justify="space-between" style={{width: "100%", paddingInline: 15, marginBottom: 10}}> 
        <Title>¡Bienvenido!</Title>
        <Typography.Text type="secondary"><b>Usuarios registrados:</b> {users?.length}</Typography.Text>
        <CreateUserDrawer />
      </Flex>
      <Row gutter={12} justify="center">
        {users?.map((user: User) => (
          <UserCard key={user.id} user={user} isLoading={isLoading} />
        ))}
      </Row>
    </Flex>
  );
}

export default UserListPage;
