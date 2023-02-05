import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";

import CreateCertificateForm from './components/Certificate_CRUD/Certificate_Create'
import EditCertificateForm from './components/Certificate_CRUD/Certificate_Edit'
import Cert_homepage from './components/Certificate_CRUD/Certificate_Homepage'
import NotFound from './components/Common/NotFound';

import Questions from './components/Questions/QuestionHomePage';
import QuestionEdit from './components/Questions/QuestionEdit';
import QuestionCreate from './components/Questions/QuestionCreate';

import CandidateList from './components/Candidate_CRUD/CandidateList'
import CandidateEdit from "./components/Candidate_CRUD/CandidateEdit";


import CandidateHomepage from './components/Candidate_Page/CandidateHomepage';

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/counter',
        element: <Counter />
    },
    {
        path: '/fetch-data',
        requireAuth: true,
        element: <FetchData />
    },
    {
        path: '/admin/certificate',
        //requireAuth: true,
        element: <Cert_homepage />
    },
    {
        path: '/admin/certificate/create',
        // requireAuth: true,
        element: <CreateCertificateForm />
    },

    {
        path: '/admin/certificate/edit/:id',
        // requireAuth: true,
        element: <EditCertificateForm />
    },
    //-----------------Questions-------------------
    {
        path: '/admin/Questions/QuestionHomePage',
        // requireAuth: true,
        element: <Questions />
    },
    {
       path: '/admin/Questions/QuestionEdit/:id',
       // requireAuth: true,
       element: <QuestionEdit />
    },
    {
        path: '/admin/Questions/QuestionCreate',
        // requireAuth: true,
        element: <QuestionCreate />
    },
    
    // -----------------Candidate-------------------
    {
        path: '/admin/candidate',
        // requireAuth: true,
        element: <CandidateList />
    },
    {
        path: '/admin/candidate/:id',
        // requireAuth: true,
        element: <CandidateEdit />
    },
    {
        path: '/candidate',
        // requireAuth: true,
        element: <CandidateHomepage />
    },
    //this needs to stay as the last path
    {
        path: '*',
        element: <NotFound />
    },
    ...ApiAuthorzationRoutes
];

export default AppRoutes;
