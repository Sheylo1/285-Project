import { Field, Form, Formik } from "formik";
import React from "react";
import { Button, Header, Input } from "semantic-ui-react";
import { useHistory } from "react-router-dom";
import { routes } from "../../../routes/config";
import { baseUrl } from "../../../constants/env-vars";
import {
  ApiResponse,
  EmployeeCreateDto,
  EmployeeGetDto,
  EmployeeUpdateDto,
} from "../../../constants/types";
import axios from "axios";
export const EmployeesUpdatePage = () => {
  const initialValues: EmployeeUpdateDto = {
      id: 0,
      userId: 0,
      positionId: 0,
      salary: 0,
      employed: false,
  };
  const history = useHistory();
  const onSubmit = async (values: EmployeeUpdateDto) => {

    values = {
        id: Number(values.id),
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
      <Header>Update Employee</Header>
      <Formik onSubmit={onSubmit} initialValues={initialValues }>
        <Form>
          <div>
            <div>
            <div className="field-label">
                <label htmlFor="Id">Id</label>
              </div>
              <Field className="field" id="Id" name="Id">
                {({ field }) => <Input {...field} />}
              </Field>
              <div className="field-label">
                <label htmlFor="userId">UserId</label>
              </div>
              <Field className="field" id="userId" name="userId">
                {({ field }) => <Input {...field} />}
              </Field>
              <div>
              <div className="field-label">
                <label htmlFor="positionId">PositionsId</label>
              </div>
              <Field className="field" id="positionId" name="positionId">
                {({ field }) => <Input {...field} />}
              </Field>
            </div>
            <div>
              <div className="field-label">
                <label htmlFor="salary">Salary</label>
              </div>
              <Field className="field" id="salary" name="salary">
                {({ field }) => <Input {...field} />}
              </Field>
            </div>
            <div>
              <div className="field-label">
                <label htmlFor="employed">Employed</label>
              </div>
              <Field className="field" id="employed" name="employed">
                {({ field }) => <Input {...field} />}
              </Field>
            </div>
            </div>
          </div>
          <div>
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
        </Form>
      </Formik>
    </>
  );
};
