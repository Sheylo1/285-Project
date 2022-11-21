import React from "react";
import { useUser } from "../../authentication/use-auth";
import { Header, Container, Divider, Card, Icon, Image } from "semantic-ui-react";
import moment from "moment";
import "./user-page.css";

export const UserPage = () => {
  const user = useUser();

  return (
    <div className="user-page-container">
      <div>
      <Divider />
        <Header>User Information</Header>
        <Container textAlign="left">
          <Divider />
        <Header size="small">Date Of Birth</Header>
          <div className="user-page-header">
          <p>{moment(user.dateOfBirth).format("MMMM Do YYYY")}</p>
          </div>
          <Divider />
          <Header size="small">First Name</Header>
          <div className="user-page-header">
          <p>{user.firstName}</p>
          </div>
          <Divider />
          <Header size="small">Last Name</Header>
          <div className="user-page-header">
          <p>{user.lastName}</p>
          </div>
          <Divider />
          <Header size="small"> Account Balance</Header>
          <div className="user-page-header">
          <p>{user.accountBalance}</p>
          </div>
          <Divider />
          <Header size="small">Email</Header>
          <div className="user-page-header">
          <p>{user.email}</p>
          </div>
          <Divider />
          <Header size="small">Phone Number</Header>
          <div className="user-page-header">
          <p>{user.phoneNumber}</p>
          </div>
          <Divider />
        </Container>
      </div>
    </div>
  );
};
