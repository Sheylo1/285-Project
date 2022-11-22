import axios from 'axios';
import React, { useEffect, useState, Component } from 'react';
import { Header, Container, Divider, Segment, Table, Button, Icon } from 'semantic-ui-react';
import { ApiResponse, CommentGetDto, UserDto } from '../../../constants/types';
import { useHistory } from 'react-router-dom';
import { routes } from '../../../routes/config';
import { useUser } from '../../../authentication/use-auth';
import "./comment-listing.css";
import moment from 'moment';

export const CommentsListingPage = () => {
    const [comments, setComments] = useState<CommentGetDto[]>()
    const user = useUser();
    console.log("debug", user)
    const history = useHistory()
    
    useEffect(() => {
        const fetchComments = async () => {
            const commentResponse = await axios.get<ApiResponse<CommentGetDto[]>>('api/comments');
            if(commentResponse.data.hasErrors){
                alert("Something went wrong.");
                return;
            }

            setComments(commentResponse.data.data);
        };

        fetchComments();
    },
    []);

    return (
    <>
        {comments && (
            <Segment>
                <h1 className="bottom-header">Comments Made Across To The Moon Gamblin</h1>
                    <div className='button'>
                        <Button color= 'green' onClick={() => history.push(routes.commentsCreate)}>
                            + Create a Message
                        </Button>
                    </div>
                    <Table celled>
                        <Table.Header>
                        <Table.Row>
                        <Table.HeaderCell>Edit</Table.HeaderCell>
                        <Table.HeaderCell>Delete</Table.HeaderCell>
                        <Table.HeaderCell>Id</Table.HeaderCell>
                        <Table.HeaderCell>Comment Date</Table.HeaderCell>
                        <Table.HeaderCell>Comment Author</Table.HeaderCell>
                        <Table.HeaderCell>Comment Message</Table.HeaderCell>
                        </Table.Row>
                        </Table.Header>
                        <Table.Body>
                            {comments.map(comment => {
                                return (
                                    <Table.Row key={comment.id}>
                                        {user?.id === comment.createdByUserId ? ( 
                                            <Table.Cell><Icon className="clickable" name='edit' onClick={() => history.push(`/comment/${comment.id}`)}/></Table.Cell> 
                                            ) : <Table.Cell></Table.Cell>}

                                        {user?.id === comment.createdByUserId ? ( 
                                            <Table.Cell><Icon className="window close" name='delete' onClick={() => history.push(`/comment/delete/${comment.id}`)}/></Table.Cell> 
                                            ) : <Table.Cell></Table.Cell>}
                                        <Table.Cell>{comment.id}</Table.Cell>
                                        <Table.Cell>{moment(comment.createdAt).format("MMMM Do YYYY")}</Table.Cell>
                                        <Table.Cell>{comment.createdByUserName}</Table.Cell>
                                        <Table.Cell>{comment.commentText}</Table.Cell>
                                    </Table.Row>
                                );
                            })}
                        </Table.Body>
                    </Table>
                    <div className = "button">
                        <Button color= 'blue' onClick={() => history.push(routes.home)}>
                            Home
                        </Button>
                    </div>
            </Segment>
    )}
        
    </>
    )
}