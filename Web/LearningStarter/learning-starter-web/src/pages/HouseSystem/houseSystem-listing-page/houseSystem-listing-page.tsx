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
     <h1 className="bottom-header">House System</h1>{" "}
          <div className='button'>
          <Button color= 'green' onClick={() => history.push(routes.housesystemCreate)}>
            + Create
          </Button>
          </div>
      {HouseSystem && (
        <Segment inverted>
          <Table celled inverted>
            {" "}
            <Table.Header>
              <Table.Row>
                {" "}
                <Table.HeaderCell></Table.HeaderCell>
                <Table.HeaderCell></Table.HeaderCell>
                <Table.HeaderCell>Payout</Table.HeaderCell>
                <Table.HeaderCell>HousePercentage</Table.HeaderCell>
              </Table.Row>
            </Table.Header>
            <Table.Body>
              {HouseSystem.map((HouseSystem) => (
                <React.Fragment key={HouseSystem.id}>
                  <Table.Row>
                  <Table.Cell><Button
                        type="button" color="yellow" onClick={() => history.push(`/houseSystem/${HouseSystem.id}`)}>Edit</Button></Table.Cell> 
                  <Table.Cell><Button
                        type="button" color="red" onClick= {() => history.push(`/houseSystem/delete/${HouseSystem.id}`)}>Delete</Button></Table.Cell>
                    <Table.Cell>${HouseSystem.payout}</Table.Cell>
                    <Table.Cell>{HouseSystem.betPercentage}%</Table.Cell>
                  </Table.Row>
                </React.Fragment>
              ))}
            </Table.Body>
          </Table>
        </Segment>
      )}
    <div className = "button">
            <Button color= 'blue' onClick={() => history.push(routes.home)}>
            Go Home
          </Button>
          </div>
    </>
  );
};