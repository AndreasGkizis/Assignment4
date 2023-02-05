import {Form,Button,Col,Row,FloatingLabel,Stack,Table,} from "react-bootstrap";

import {FormGroup,Badge,Dropdown,FormCheck,radio,checkbox,Feedback,} from "react-bootstrap";
import Multiselect from "multiselect-react-dropdown";
import { React, useState, useEffect } from "react";
import { Link,useParams } from "react-router-dom";

import axios from "axios";

import { useLocation } from "react-router-dom";

import Editor from "./Editor";
//------------------------------------------------//QUESTION EDIT COMPONENT------------------------------------------------>>>>>>>
export default  function QuestionEdit() {
  //------------------------------------------------Question state
  const [question, setQuestion] = useState({
    text: "string",
    topicId: 0,
    difficultyLevelId: 0,

    options: [],
  });

  const [options, setOptions] = useState([{}, {}, {}, {}]);
  
  const _params = useParams();
  const params = _params.id;
  //------------------------------------------------Topics state
  const [allTopics, setAllTopics] = useState([]);
  //------------------------------------------------Difficulty levels state
  const [difficultyLevels, setLevels] = useState([]);
  //--------------------------------------------------->>>>>>>>
  const location = useLocation();
  const { questionIndex } = location.state;
//------------------------------------------------//GET ALL TOPICS AND DIFFICULTY LEVELS
const url = "https://localhost:7196/api/Questions/" + params;
//
  useEffect(() => { 
  axios
    .get(`https://localhost:7196/api/Topics`)
    .then((res) => {
      setAllTopics(res.data.data);
    })
    .catch((err) => {
      console.error(err.response.data);
    });
//------------------------------------------------//GET DIFFICULTY LEVELS
  axios
    .get(`https://localhost:7196/api/DifficultyLevels`)
    .then((res) => {
      setLevels(res.data.data);
      // console.log(res.data.data);
    })
    .catch((err) => {
      console.error(err.response.data);
    });
//------------------------------------------------//GET QUESTION BY ID
    axios
    .get(url )
    .then((response) => {
      setQuestion(response.data.data);
      setOptions(response.data.data.options);
    });



}, [url]);
  //------------------------------------------------HANDLE SUBMIT------------------------------------------------>>>>>>
  const handleSubmit = (event) => {
    event.preventDefault();
    console.log(question);
    // axios.put('https://localhost:7196/api/Questions/'+questionIndex,question)
    // .then((response) => {  setQuestion(response.data.data);
    // });
  };
  //------------------------------------------------HANDLE CHANGE------------------------------------------------>>>>>>

  const handleChange = (event,name,data,questionOptionIndex) =>
   {
     console.log("IN HANDLE CHANGE");

       if(name==="QuestionText")
        {
          console.log("Inside QuestionText condition")
          setQuestion(...question, {text:data});
        }
        // else if(name==="OptionText0")
        // {  
        //   console.log("Boom OptionText0")
          // setQuestion({ ...question , options:[{...question.options[0],text:data}]  });
        
       
        console.log(options);
 




  };

      
  //------------------------------------------------HANDLE SELECT------------------------------------------------>>>>>>
  const onSelect = (selectedList, selectedItem) => 
  {


  };
  //--------------------------------------------------->>>>>>>>

   
 return   (
    <Form noValidate validated={true} onSubmit={handleSubmit}>
      {" "}
      {/* ||FORM------------------------------------------------->>>>>>> */}
      <Stack gap={5}>
        <Row key={'questionEditorAndDropdowns'}>
          {/* Questions text */}
          <Col md={7}>
            <FormGroup required>
              <Form.Label>Questions Text</Form.Label>
               
                           <Editor handleChange={ handleChange } name={"QuestionText"} text={question.text} />

            </FormGroup>
          </Col>
          {/* DROPDOWN TOPICS */}
          <Col md={3}>
            <Form.Group>
              <Form.Label></Form.Label>
              <Dropdown autoClose={"outside"} onSelect={onSelect} required>
                <Dropdown.Toggle variant="primary" id="dropdown-basic">
                  Question's Topic
                </Dropdown.Toggle>

                <Dropdown.Menu>
                  {allTopics.map((topic, index) => (
                    <Dropdown.Item
                      key={index}
                      value={topic.id}
                      eventKey={topic.id}
                      species={"topic"}
                    >
                      {topic.name}
                    </Dropdown.Item>
                  ))}
                </Dropdown.Menu>
              </Dropdown>
            </Form.Group>
          </Col>{" "}
          {/*  DROPDOWN Difficulty levels */}
          <Col md={2}>
            <Form.Group>
              <Form.Label></Form.Label>
              <Dropdown autoClose={"outside"} onSelect={onSelect}>
                <Dropdown.Toggle variant="primary" id="dropdown-basic">
                  Difficulty
                </Dropdown.Toggle>

                <Dropdown.Menu>
                  {difficultyLevels.map((level, index) => (
                    <Dropdown.Item
                      key={index}
                      value={level.id}
                      eventKey={level.id}
                      species={"level"}
                    >
                      {level.difficulty}
                    </Dropdown.Item>
                  ))}
                </Dropdown.Menu>
              </Dropdown>
            </Form.Group>
          </Col>
          {/*  DROPDOWN Question OPTIONS */}
        </Row>

                   
              

              <Row key={"unique0"}>
                        <Col md={7}>
                          <Form.Group>
                            <Form.Label>Option 0</Form.Label>
                        
                        <Editor handleChange={handleChange} name={"OptionText0"} text={'option.text'} />

                          </Form.Group>
                        </Col>
                        <Col>
                              <Form.Check type={'checkbox'} id={1} label={"Is Correct"} 
                              onChange={(event,index) => handleChange(event,index)} name={"checkbox0"} checked={true}/> 
                              </Col>
                      </Row>

        <Row key={'CreateButtonRow'}>
          <Col md={30}>
            <Button variant="primary" type="submit" value={"Submit"}>
              Create Question
            </Button>
          </Col>
        </Row>
      </Stack>
    </Form>
  );
}














{/* {  question.options.map((option, index) => 
                    {
                  return  (
                      <Row key={index+"unique"}>
                        <Col md={7}>
                          <Form.Group>
                            <Form.Label>Option {index + 1}</Form.Label>
                        
                        <Editor handleChange={handleChange} name={"OptionText"+index} text={option.text} />

                        <p>testing</p>
                          </Form.Group>
                        </Col>
                        <Col>
                              <Form.Check type={'checkbox'} id={index+1} label={"Is Correct"} 
                              onChange={(event,index) => handleChange(event,index)} name={"checkbox"+index} checked={option.correct}/> 
                              </Col>
                      </Row>)
                    
                  })}   */}