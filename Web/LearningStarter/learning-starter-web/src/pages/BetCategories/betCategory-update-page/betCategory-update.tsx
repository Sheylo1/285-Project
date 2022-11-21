import axios from "axios";
import { Field, Form, Formik } from "formik";
import React, { useEffect, useState } from "react";
import { Button, Header, Icon, Input, Label, Segment, Table } from "semantic-ui-react";
import { ApiResponse, BetCategoryGetDto, BetCategoryUpdateDto } from "../../../constants/types";
import { useRouteMatch } from "react-router-dom";
import { routes } from "../../../routes/config";
import {useHistory} from "react-router-dom";
import { BaseUrl } from "../../../constants/env-vars";
import "./betCategory-update.css";

export const BetCategoriesUpdatePage = () => {
    const [betCategory, setBetCategory] = useState<BetCategoryGetDto>();
    const {params} = useRouteMatch();
    const id = Number(params.id);

    const history = useHistory();

    useEffect(() => {
      const getBetCategory = async () => {
            const {data: response} = await axios.get<ApiResponse<BetCategoryGetDto>>(
                `${BaseUrl}/Api/betCategories/${id}`
            );

            if(response.hasErrors){
                alert(response.errors[0].message);
                return;
            }

            setBetCategory(response.data);
      };

      getBetCategory();
    }, []);

    
    const onSubmit = async (values: BetCategoryUpdateDto) => {
        const { data: response } = await axios.put<ApiResponse<BetCategoryGetDto>>(
            `${BaseUrl}/Api/betCategories/${id}`,
            values
        );

        if (response.hasErrors) {
            alert(response.errors[0].message);
            return;
        }

        history.push(routes.betCategories.listing);
    };


    return (
        <>
        <div className="betCategory-update-header-container">
        <Header>
                        <Label as='a' color='yellow' size='huge'><Icon className="settings"></Icon>Change Category Name</Label>
                </Header>
        </div>
        <div className="betCategory-update-container">
        {betCategory && (
        <Formik initialValues = {betCategory} onSubmit = {onSubmit}>    
        <Form>
            <Table inverted>
                <Table.Body>
                    <Table.Row>
                        <Table.Cell>
                            <Field id="name" name="name">
                                {({ field }) => <Input {...field } />}
                            </Field>
                        </Table.Cell>
                    </Table.Row>
                    <Table.Row>
                        <Table.Cell>
                            <div className="betCategory-update-container">
                                <Button type="submit" color="green">Change</Button> 
                                <Button onClick= {() => history.push(`/betCategoryListing`)} icon="left arrow" color="blue"></Button>
                            </div>
                        </Table.Cell>
                    </Table.Row>
                </Table.Body>
            </Table>

        </Form>
        </Formik>
        )}
        </div>
        </>
        );
    };
