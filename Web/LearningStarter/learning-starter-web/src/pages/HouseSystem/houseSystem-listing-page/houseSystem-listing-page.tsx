import axios from "axios";
import React from "react";
import { Button, Icon, Segment, Table } from "semantic-ui-react";
import Header from "semantic-ui-react/dist/commonjs/elements/Header/Header";
import { ApiResponse, HouseSystemGetDto } from "../../../constants/types";
import {useHistory} from 'react-router-dom'
import { routes } from "../../../routes/config";

export const HouseSystemListingPage = () => {
  const [HouseSystem, setHouseSystem] = React.useState<HouseSystemGetDto[]>();
    const history = useHistory()
  console.log(HouseSystem);
  React.useEffect(() => {
    const fetchHouseSystem = async () => {
      const response = await axios.get<ApiResponse<HouseSystemGetDto[]>>(
        "api/house-systems"
      );
      if (response.data.hasErrors) {
        alert("Something went wrong.");
        return;
      }

      setHouseSystem(response.data.data);
    };

    fetchHouseSystem();
  }, []);
  return (
    <>
      {HouseSystem && (
        <Segment>
          <Header>House System</Header>{" "}
          <div className='button'>
          <Button color= 'green' onClick={() => history.push(routes.housesystemCreate)}>
            + Create
          </Button>
          </div>
          <Table celled>
            {" "}
            <Table.Header>
              <Table.Row>
                {" "}
                <Table.HeaderCell>Edit</Table.HeaderCell>
                <Table.HeaderCell>Delete</Table.HeaderCell>
                <Table.HeaderCell>Id</Table.HeaderCell>
                <Table.HeaderCell>Payout</Table.HeaderCell>
                <Table.HeaderCell>HousePercentage</Table.HeaderCell>
              </Table.Row>
            </Table.Header>
            <Table.Body>
              {HouseSystem.map((HouseSystem) => (
                <React.Fragment key={HouseSystem.id}>
                  <Table.Row>
                  <Table.Cell><Icon className="clickable" name='edit' onClick={() => history.push(`/houseSystem/${HouseSystem.id}`)}/></Table.Cell> 
                  <Table.Cell><Icon className="clickable" name='delete' onClick= {() => history.push(`/houseSystem/delete/${HouseSystem.id}`)}/></Table.Cell>
                    <Table.Cell>{HouseSystem.id}#</Table.Cell>
                    <Table.Cell>${HouseSystem.payout}</Table.Cell>
                    <Table.Cell>{HouseSystem.betPercentage}%</Table.Cell>
                  </Table.Row>
                </React.Fragment>
              ))}
            </Table.Body>
          </Table>
          <div className = "button">
            <Button color= 'blue' onClick={() => history.push(routes.home)}>
            Go Home
          </Button>
          </div>
        </Segment>
      )}
    </>
  );
};