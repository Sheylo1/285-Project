import axios from "axios";
import { Field, Form, Formik } from "formik";
import React from "react";
import { Input, Button, Header, Table, Segment, Icon, Label } from "semantic-ui-react";
import { ApiResponse, BetCategoryCreateDto, BetCategoryGetDto } from '../../../constants/types'
import {useHistory, useRouteMatch} from "react-router-dom";
import { routes } from "../../../routes/config";
import { BaseUrl } from "../../../constants/env-vars";
import "./betCategory-create.css";
const initialValues: BetCategoryCreateDto = {
    name: "",
};

export const BetCategoriesCreatePage = () => {
    let match = useRouteMatch<{ id: string }>();
    const id = match.params.id;
    const history = useHistory();

const onSubmit = async (values: BetCategoryCreateDto) => {
    const response = await axios.post<ApiResponse<BetCategoryGetDto>>(`${BaseUrl}/Api/betCategories`,
    values
    );

    if(response.data.hasErrors) {
        response.data.errors.forEach((err) => {
            console.log(err.message);
        });
    } else {
        history.push(routes.betCategories.listing);
    }
};

    return (
        <>
                <div className="betCategory-createheader-container">
                <Header>
                        <Label as='a' color='green' size='huge'><Icon className="plus"></Icon>Enter New Category</Label>
                </Header>
        </div>
        <div className="betCategory-create-container">
            <Formik initialValues={initialValues} onSubmit={onSubmit}>
                <Form>
                    <Table inverted >
                        <Table.Body >
                            <Table.Row>
                                <Table.Cell>
                                     <Field id="name" name="name">
                                        {({field}) => <Input placeholder="Category Name" {...field} />}
                                     </Field>
                                </Table.Cell>
                            </Table.Row>
                            <Table.Row>
                                <Table.Cell>
                                    <div className="betCategory-create-container">
                                        <Button type="submit" color="green">Create</Button>
                                        <Button onClick= {() => history.push(`/betCategoryListing`)} icon="left arrow" color="blue"></Button>
                                    </div>
                                </Table.Cell>
                            </Table.Row>

                        </Table.Body>
                    </Table>
                </Form>
            </Formik>
            </div>
            <h3 className="allaroundred">Must enter at least 3 char and less than 32 char</h3>
        </>
  );
};