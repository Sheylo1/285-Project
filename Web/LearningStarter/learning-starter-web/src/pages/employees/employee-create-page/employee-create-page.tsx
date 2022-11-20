import { Field, Form, Formik } from "formik";
import React from "react";
import { Button, Header, Input } from "semantic-ui-react";
import { useHistory } from "react-router-dom";
import { routes } from "../../../routes/config";
//import { baseUrl } from "../../../constants/env-vars";
import "./employee-create-page.css";

import {
  ApiResponse,
  EmployeeCreateDto,
  EmployeeGetDto,
} from "../../../constants/types";
import axios from "axios";
export const EmployeesCreatePage = () => {
  const initialValues: EmployeeCreateDto = {
    userId: 0,
    positionId: 0,
    salary: 0,
    employed: false,
  };
  const history = useHistory();
  const onSubmit = async (values: EmployeeCreateDto) => {

    values = {
        userId: Number(values.userId),
        positionId: Number(values.positionId),
        salary: Number(values.salary),
        employed: Boolean(values.employed),

    }

    const response = await axios.post<ApiResponse<EmployeeGetDto>>(
      "/api/employees",
      values
    );

    if (response.data.hasErrors) {
      alert("Something went wrong.");
      return;
    }else{
            alert("Nothing went wrong!");
     history.push(routes.employees);
    }


  };
  return (
    <>
      <h2 className="employeecreate-header">Add New Employee</h2>
      <Formik onSubmit={onSubmit} initialValues={initialValues }>
        <Form>
          <div>
            <div>
              <div className="employeecreate1-header">
                <label htmlFor="userId">UserId</label>
                </div>
                <div className="employeecreate1-header">
              <Field className="field" id="userId" name="userId">
                {({ field }) => <Input placeholder="UserId" {...field} />}
              </Field>
              </div>
              <div>
              <div className="employeecreate1-header">
                <label htmlFor="positionId">PositionsId</label>
                </div>
                <div className="employeecreate1-header">
              <Field className="field" id="positionId" name="positionId">
                {({ field }) => <Input placeholder="PositionId" {...field} />}
              </Field>
              </div>
            </div>
            <div>
            <div className="employeecreate1-header">
                <label htmlFor="salary">Salary</label>
              </div>
              <div className="employeecreate1-header">
              <Field className="field" id="salary" name="salary">
                {({ field }) => <Input placeholder="Salary" {...field} />}
              </Field>
              </div>
            </div>
            <div>
            <div className="employeecreate1-header">
                <label htmlFor="employed">Employment</label>
              </div>
              <div className="employeecreate1-header">
              <Field className="field" id="employed" name="employed">
                {({ field }) => <Input placeholder="Employment" {...field} />}
              </Field>
              </div>
            </div>
            </div>
          </div>
          <div>
            <div className="employeecreate-buttons">
            <Button
              primary
              type="submit"
               //onClick={() => history.push(routes.employees)}
            >
              Submit
            </Button>
            <Button
              secondary
              type="button"
               onClick={() => history.push(routes.employees)}
            >
              Cancel
            </Button>
            </div>
          </div>
        </Form>
      </Formik>
    </>
  );
};
