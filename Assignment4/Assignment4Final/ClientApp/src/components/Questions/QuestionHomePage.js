import { Form, Button, Col, Row, FloatingLabel, Stack , Table, Container  } from 'react-bootstrap';
import {React,useState,useEffect} from 'react';

import axios from 'axios';
import { Link,NavLink } from 'react-router-dom';
import Delete from './QuestionDelete';
import QuestionEdit from './QuestionEdit';
function Questions()
{
    const[data,setData] = useState([]);


    useEffect(() => {
        axios.get('https://localhost:7196/api/Questions').then((response) => {  setData(response.data.data);
        });
      }, []);
   
      //--------------------------------------------------
      //filters the text from the raw html 
      function Replace(temp)
      {
        var parser = new DOMParser();

        var doc = parser.parseFromString(temp,'text/html');

        return doc.body.innerText;

      }
      //--------------------------------------------------

    return (

        <Container fluid="md">
            <Link to="/admin/Questions/QuestionCreate"><Button variant='dark'>Create new Question</Button></Link> 
            <div>
                <Table hover striped >
                                <thead>
                                    <tr>

                                    <th scope='Col'>Id</th>
                                    <th scope='col'>MainText</th>
                                    <th scope='col'>Topic</th>
                                    <th scope='col'></th>
                                    <th scope='col'></th>

                                    </tr>
                                </thead>

                                <tbody>
                        
                                        {data.map((item,index) => (
                                            <tr key={item.id}>
                                                <td>{item.id != null && item.id}</td>
                                                <td>{Replace(item.text)}</td>
                                                <td>{item.topic === null ? "No topic selected" : item.topic.name}</td>

                                               
                                                {/* <td><Link  to="/admin/Questions/QuestionEdit"> <Button  onClick={(event) => QuestionEdit(event)} name={index}>Edit</Button></Link> </td> */}
                                
                                

                                                {/* <td>
                                                    <Link to="/admin/Questions/QuestionEdit">
                                                        <Button variant='dark' onClick={(event) => QuestionEdit(event)} name={index} custom={"my custom"}>Edit</Button>
                                                        </Link>
                                                </td> */}
                                                <td>
                                                    <Link to="/admin/Questions/QuestionEdit" state={{questionIndex:item.id}}>
                                                        <Button variant='dark' >Edit</Button>
                                                        </Link>
                                                </td>

                                                <td><Link to=""><Button variant='dark' onClick={(event) => Delete(event)} name={index}>Delete</Button></Link></td>
                                            </tr>
                                            
                                            ))}
                                </tbody>
                    </Table>
            </div>
          
              
        </Container>
    )
    


}



















export default Questions;