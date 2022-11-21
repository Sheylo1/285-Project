import { Field, Form, Formik } from "formik";
import React from "react";
import { Button, Header, Input } from "semantic-ui-react";
import { useHistory, useRouteMatch} from "react-router-dom";
import { routes } from "../../../routes/config";
import "./employee-update-page.css";
import {
  ApiResponse,
  EmployeeGetDto,
  EmployeeUpdateDto,
} from "../../../constants/types";
import axios from "axios";
export const EmployeesUpdatePage = () => {
  let match = useRouteMatch<{ id: string }>();
  const id = match.params.id;

  const initialValues: EmployeeUpdateDto = {
    // id: 0,
    userId: 0,
    positionId: 0,
    salary: 0,
    employed: false,
  };
  const history = useHistory();
  const onSubmit = async (values: EmployeeUpdateDto) => {
    values = {
    //   id: Number(values.id),
      userId: Number(values.userId),
      positionId: Number(values.positionId),
      salary: Number(values.salary),
      employed: Boolean(values.employed),
    };

    const response = await axios.put<ApiResponse<EmployeeGetDto>>(
      `/api/employees/${id}`,
      values
    );

    if (response.data.hasErrors) {
      alert("Something went wrong.");
      return;
    } else {
      alert("Nothing went wrong!");
      history.push(routes.employees);
    }
  };
  return (
    <>
      <h2 className="employeeupdate-header">Update Employee</h2>
      <Formik onSubmit={onSubmit} initialValues={initialValues}>
        <Form>
          <div>
            <div>
            <div className="employeeupdate1-header">
                <label htmlFor="userId">UserId</label>
              </div>
              <div className="employeeupdate1-header">
              <Field className="field" id="userId" name="userId">
                {({ field }) => <Input placeholder="UserId" {...field} />}
              </Field>
              </div>
              <div>
              <div className="employeeupdate1-header">
                  <label htmlFor="positionId">PositionsId</label>
                </div>
                <div className="employeeupdate1-header">
                <Field className="field" id="positionId" name="positionId">
                  {({ field }) => <Input placeholder="PositionId" {...field} />}
                </Field>
                </div>
              </div>
              <div>
              <div className="employeeupdate1-header">
                  <label htmlFor="salary">Salary</label>
                </div>
                <div className="employeeupdate1-header">
                <Field className="field" id="salary" name="salary">
                  {({ field }) => <Input placeholder="Salary" {...field} />}
                </Field>
                </div>
              </div>
              <div>
              <div className="employeeupdate1-header">
                  <label htmlFor="employed">Employment</label>
                </div>
                <div className="employeeupdate1-header">
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

