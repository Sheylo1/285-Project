import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { Segment, Header, Table, Button, Icon, Menu, Label } from 'semantic-ui-react';
import { BaseUrl } from '../../../constants/env-vars';
import { ApiResponse, BetCategoryGetDto } from '../../../constants/types';
import { useRouteMatch } from "react-router-dom";
import {useHistory} from "react-router-dom";
import "./betCategory-listing.css";

export const BetCategoriesListingPage = () => {
const [BetCategories, setBetCategories] = useState<BetCategoryGetDto[]>();
console.log({BetCategories})
let match = useRouteMatch<{ id: string }>();
const id = match.params.id;
const history = useHistory();

useEffect (() => {
    const fetchBetCategories = async () => {
            const response = await axios.get<ApiResponse<BetCategoryGetDto[]>>('Api/betCategories');
            if(response.data.hasErrors){
                alert("something went wrong.");
                return;
            }

            setBetCategories(response.data.data);
    }

    fetchBetCategories();
}, []);

    return(
    <>
      {BetCategories && (
        <Segment>
          <h1 className="bottom-header">Bet Categories</h1>
          <div className='center'>
          <Button onClick= {() => history.push(`/betcategorycreate`)} color="green">+ Create new Category</Button>
          </div>
       <div className="betCategory-listing-container">
      </div>
            <Table celled>
              <Table.Header>
                <Table.Row>
                    <Table.HeaderCell>Edit</Table.HeaderCell>
                    <Table.HeaderCell>Delete</Table.HeaderCell>
                    <Table.HeaderCell>Id</Table.HeaderCell>
                    <Table.HeaderCell>Name</Table.HeaderCell>
                </Table.Row>
              </Table.Header>
              <Table.Body>
                {BetCategories.map((betCategory) => {
                  return (
                    <Table.Row key={betCategory.id }>
                      <Table.Cell><Icon name="edit" onClick= {() => history.push(`/betcategoryupdate/${betCategory.id}`)}></Icon></Table.Cell>
                      <Table.Cell>
                        <Icon name="window close" onClick= {() => history.push(`/betcategorydelete/${betCategory.id}`)}></Icon>
                      </Table.Cell>
                      <Table.Cell>{betCategory.id}</Table.Cell>
                      <Table.Cell>{betCategory.name}</Table.Cell>
                    </Table.Row>
                  );
                })}

                </Table.Body>
            </Table>
            <div className='button'>
              <Button onClick= {() => history.push(`/home`)} icon="home" color="blue">Home</Button>
            </div>
        </Segment>
      )}
    </>
  );
};