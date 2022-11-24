import React from "react";
import { useUser } from "../../authentication/use-auth";
import { Header, Container, Divider, Card, Icon, Image, Button } from "semantic-ui-react";
import moment from "moment";
import "./user-page.css";
import { routes } from "../../routes/config";
import { useHistory } from "react-router-dom";

export const UserPage = () => {
  const user = useUser();
  const history = useHistory();

  return (
      <div>
        <h1 className="whitenames">User Information</h1>
          <Divider />
        <h2 className="whitenames1">Date Of Birth</h2>
          <div className="user-page-header">
          <p>{moment(user.dateOfBirth).format("MMMM Do YYYY")}</p>
          </div>
          <Divider />
          <h3 className="whitenames1">First Name</h3>
          <div className="user-page-header">
          <p>{user.firstName}</p>
          </div>
          <Divider />
          <h4 className="whitenames1">Last Name</h4>
          <div className="user-page-header">
          <p>{user.lastName}</p>
          </div>
          <Divider />
          <h5 className="whitenames1"> Account Balance</h5>
          <div className="user-page-header">
          <p>${user.accountBalance}</p>
          </div>
          <Divider />
          <h6 className="whitenames1">Email</h6>
          <div className="user-page-header">
          <p>{user.email}</p>
          </div>
          <Divider />
          <h6 className="whitenames1">Phone Number</h6>
          <div className="user-page-header">
          <p>{user.phoneNumber}</p>
          </div>
          <Divider />
          <h6 className="whitenames1">Update Info</h6>
          <div className="user-page-header">
          <Button color= 'yellow' onClick={() => history.push(routes.userUpdate)}>
            Edit
          </Button>
          </div>
          <Divider />
          <h6 className="whitenames1">Delete Account?</h6>
          <div className="user-page-header">
          <Button color= 'red' onClick={() => history.push(routes.userDelete)}>
            Delete
          </Button>
          </div>
      </div>
  );
};
