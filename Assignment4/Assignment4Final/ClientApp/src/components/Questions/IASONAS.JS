import { Form, Button, Col, Row, FloatingLabel, Stack , Table, Container,Modal  } from 'react-bootstrap';
import {React,useState,useEffect} from 'react';

import axios from 'axios';
import { Link } from 'react-router-dom';
import QuestionEdit from './QuestionEdit';
import QuestionDelete from './QuestionDelete'
function Questions()
{
    const[data,setData] = useState([]);


    //---------------------------MODAL ------------------------>>>>>>>>
    const [show, setShow] = useState(false);
    


  const handleClose = (event) => 
  {
    console.log(event);
    setShow(false);
}

  const handleShow = (event) =>
  {
    console.log(event.target.name);
    setShow(true);
  }
// --------------------------------------------------->>>>>>>>>>>>>>>


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

                                                <td>
                                                    <Link to={"/admin/Questions/QuestionEdit/"+item.id} state={{questionIndex:item.id}}>
                                                        <Button variant='dark' >Edit</Button>
                                                        </Link>
                                                </td>

                                                <td><Button variant='dark' onClick={handleShow} name={index}>Delete</Button></td>
                                            </tr>
                                            
                                            ))}
                                </tbody>
                    </Table>



                            <Modal show={show} onHide={handleClose}>
                                        <Modal.Header closeButton>
                                        <Modal.Title>QuestionDelete</Modal.Title>
                                        </Modal.Header>
                                        <Modal.Body>Are you sure you want to delete this question?</Modal.Body>
                                        <Modal.Footer>

                                        <Button variant="secondary" onClick={handleClose}>
                                            Close
                                        </Button>
                                        <Button variant="primary" onClick={handleClose}>
                                            Delete
                                        </Button>
                                        </Modal.Footer>
                            </Modal>
            </div>
          
              
        </Container>
    )
    


}



















export default Questions;