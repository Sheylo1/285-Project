import axios from "axios";
import { Field, Form, Formik } from "formik";
import React, { useEffect, useState } from "react";
import { Button, Header, Icon, Input, Label, Segment, Table } from "semantic-ui-react";
import { ApiResponse, BetCategoryGetDto, BetCategoryUpdateDto } from "../../../constants/types";
import { useRouteMatch } from "react-router-dom";
import { routes } from "../../../routes/config";
import {useHistory} from "react-router-dom";
import { BaseUrl } from "../../../constants/env-vars";
import "./betCategory-delete.css";

export const BetCategoriesDeletePage = () => {
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

    
    const onSubmit = async (values: BetCategoryGetDto) => {
        const { data: response } = await axios.delete<ApiResponse<BetCategoryGetDto>>(
            `${BaseUrl}/Api/betCategories/${id}`,
        );

        if (response.hasErrors) {
            alert(response.errors[0].message);
            return;
        }

        history.push(routes.betCategories.listing);
    };


    return (
        <>
        <div className="betCategory-deleteheader-container">
        <Header>
                        <Label as='a' color='red' size='huge'><Icon className="trash alternate"></Icon>Delete Category?</Label>
                </Header>
        </div>
        <div className="betCategory-delete-container">
        {betCategory && (
        <Formik initialValues = {betCategory} onSubmit = {onSubmit}>    
            <Form>
                <Table inverted>
                    <Table.Body>
                        <Table.Row>
                            <Table.Cell>
                                <Button type="submit" color="red">Yes</Button> 
                                <Button onClick= {() => history.push(`/betCategoryListing`)}color="blue">No</Button>
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
