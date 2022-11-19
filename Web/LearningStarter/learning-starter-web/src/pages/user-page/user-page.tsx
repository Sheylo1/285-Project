import React from "react";
import { useUser } from "../../authentication/use-auth";
import { Header, Container, Divider } from "semantic-ui-react";
import moment from "moment";
import "./user-page.css";

export const UserPage = () => {
  const user = useUser();

  return (
    <div className="user-page-container">
      <div>
        <Header>User Information</Header>
        <Container textAlign="left">
          <Header size="small">First Name</Header>
          <p>{user.firstName}</p>
          <Divider />
          <Header size="small">Last Name</Header>
          <p>{user.lastName}</p>
          <Divider />
          <Header size="small"> Account Balance</Header>
          <p>{user.accountBalance}</p>
          <Divider />
          <Header size="small">Email</Header>
          <p>{user.email}</p>
          <Divider />
          <Header size="small">Phone Number</Header>
          <p>{user.phoneNumber}</p>
          <Divider />
          <Header size="small">Date Of Birth</Header>
          <p>{moment(user.dateOfBirth).format("MMMM Do YYYY")}</p>
          <Divider />
        </Container>
      </div>
    </div>
  );
};
