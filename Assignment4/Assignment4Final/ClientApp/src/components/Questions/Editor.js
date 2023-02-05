import React from "react";

import { CKEditor } from "@ckeditor/ckeditor5-react";
import EditorPlus from "ckeditor5-classic-plus";

function Editor(props) {
  return (
    <div>

      <CKEditor
        editor={EditorPlus}
        event={props.event}
        data={props.text}
        name={props.name}

        // data="<p>Hello from CKEditor 5!</p>" 

        config={{ placeholder: props.placeholderText }}
        onReady={(editor) => {
          /* You can store the "editor" and use when it is needed. */
          console.log('Editor is ready to use!');
        }}
        // optionId={props.optionId}

        onChange={(event, editor, name) => 
            {
                    // console.log(event);
                    // console.log("Inside Editor component");
                    const data = editor.getData();
                    console.log(data);

                    name = props.name;
                    // console.log(name);

                //  optionId=props.optionId;
                //     console.log(optionId);   

                    props.handleChange(event, name, data, );
        }}

        required

        />
    </div>
  );
}

export default Editor;

// editor={EditorPlus}
// data={question.text}
// onReady={editor => {
//   // You can store the "editor" and use when it is needed.
// }}

// onChange={(event, editor) => {
    //   const data = editor.getData();
    //   handleChange(data,event,editor);
    // }}
// // config={{
// //   simpleUpload: {
    // //     // The URL that the images are uploaded to.
    // //     uploadUrl: "https://localhost:44473/admin/Questions/QuestionCreate",
    
    // //     // Enable the XMLHttpRequest.withCredentials property if required.
    // //     withCredentials: true,
    
    // //     // Headers sent along with the XMLHttpRequest to the upload server.
    // //     headers: {
        // //       "X-CSRF-TOKEN": "CSFR-Token",
// //       Authorization: "Bearer <JSON Web Token>"
// //     }
// //   }
// // }}








// config={{
//   simpleUpload: {
//     // The URL that the images are uploaded to.
//     uploadUrl: "https://localhost:44473/admin/Questions/QuestionCreate",

//     // Enable the XMLHttpRequest.withCredentials property if required.
//     withCredentials: true,

//     // Headers sent along with the XMLHttpRequest to the upload server.
//     headers: {
//       "X-CSRF-TOKEN": "CSFR-Token",
//       Authorization: "Bearer <JSON Web Token>"
//     }
//   }
// }}