import axios from "axios";
import React from "react";
import { Button, Icon, Segment, Table } from "semantic-ui-react";
import Header from "semantic-ui-react/dist/commonjs/elements/Header/Header";
import { ApiResponse, EmployeeGetDto } from "../../../constants/types";
import {useHistory} from 'react-router-dom'
import { routes } from "../../../routes/config";
//import { baseUrl } from "../../../constants/env-vars";

export const EmployeesListingPage = () => {
  const [employees, setEmployees] = React.useState<EmployeeGetDto[]>();
    const history = useHistory()
  console.log(employees);
  React.useEffect(() => {
    const fetchEmployees = async () => {
      const response = await axios.get<ApiResponse<EmployeeGetDto[]>>(
        "api/employees"
      );
      if (response.data.hasErrors) {
        alert("Something went wrong.");
        return;
      }

      setEmployees(response.data.data);
    };

    fetchEmployees();
  }, []);
  return (
    <>
    <h1 className="bottom-header">Employees</h1>{" "}
          <div className='button'>
          <Button color= 'green' onClick={() => history.push(routes.employeescreate)}>
            + Create
          </Button>
          </div>
      {employees && (
        <Segment inverted>
          <Table celled inverted>
            {" "}
            <Table.Header>
              <Table.Row>
                {" "}
                <Table.HeaderCell></Table.HeaderCell>
                <Table.HeaderCell>User</Table.HeaderCell>
                <Table.HeaderCell>Position</Table.HeaderCell>
                <Table.HeaderCell>Salary</Table.HeaderCell>
                <Table.HeaderCell>Employed</Table.HeaderCell>
              </Table.Row>
            </Table.Header>
            <Table.Body>
              {employees.map((employee) => (
                <React.Fragment key={employee.id}>
                  <Table.Row>
                  <Table.Cell><Button
                        type="button" color="yellow" onClick= {() => history.push(`employees/${employee.id}`)}>Edit</Button></Table.Cell>
                    <Table.Cell>{employee.userId}</Table.Cell>
                    <Table.Cell>{employee.positionId}</Table.Cell>
                    <Table.Cell>${employee.salary}</Table.Cell>
                    <Table.Cell>{employee.employed.toString()}</Table.Cell>
                  </Table.Row>
                </React.Fragment>
              ))}
            </Table.Body>
          </Table>
        </Segment>
      )}
    <div className = "button">
            <Button color= 'blue' onClick={() => history.push(routes.home)}>
            Home
          </Button>
          </div>
    </>
  );
};
