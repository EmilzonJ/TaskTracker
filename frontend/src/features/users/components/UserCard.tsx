import { Card, Col, Avatar, Badge } from "antd";
import { User } from "../types/user.type";
import { useNavigate } from "react-router-dom";
const { Meta } = Card;

function UserCard({ user, isLoading }: { user: User; isLoading: boolean }) {
  const navigate = useNavigate();

  const handleClick = () => {
    navigate(`/users/${user.id}/tasks`);
  };

  return (
    <Col span={18} md={12} style={{ marginBottom: 30 }}>
      <Badge.Ribbon text="Usuario" color="green">
        <Card
          bordered={false}
          hoverable
          loading={isLoading}
          onClick={() => handleClick()}
        >
          <Meta
            style={{ minHeight: 80 }}
            avatar={
              <Avatar src="https://api.dicebear.com/7.x/miniavs/svg?seed=8" />
            }
            title={`${user.name} ${user.surname}`}
            description={`Email: ${user.email} Teléfono: ${user.phone}`}
          />
        </Card>
      </Badge.Ribbon>
    </Col>
  );
}

export default UserCard;
