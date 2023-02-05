import {React,useState} from "react";
import { Modal } from "react-bootstrap";
import { Button } from "react-bootstrap";



function  Delete(props) {


console.log('In delete modal');

    function afterOpenModal () {
        console.log("after open modal");
    }

    function onModalClose ()
     {
        props.setModalIsOpen(false);
    }

const [show,setShow] = useState(true);

const handleClose = () => setShow(false);
const handleShow = () => setShow(true);







return (
    <div  className="modal show" style={{ display: 'block', position: 'initial' }}>
        <Modal
        isOpen={true}
        onAfterOpen={e => afterOpenModal(e)}
        ariaHideApp={false}
      >
                {/* <Modal.Dialog>    */}
                    <Modal.Header closeButton>
                        <Modal.Title>Modal title</Modal.Title>
                    </Modal.Header>

                    <Modal.Body>
                        <p>Modal body text goes here.</p>
                    </Modal.Body>

                    <Modal.Footer>
                        <Button variant="secondary" onClick={handleClose}>Close</Button>
                        <Button variant="primary" onClick={handleClose}>Save changes</Button>
                    </Modal.Footer> 
                {/* </Modal.Dialog> */}
    </Modal>


    </div>


  

)

}

export default Delete;