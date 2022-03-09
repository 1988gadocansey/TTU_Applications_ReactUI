import {combineReducers} from "redux";
import userReducer from "./UserReducer";
import avatarReducer from "./AvatarReducer";
import formReducer from "./FormReducer";
import resultReducer from "./ResultReducer";
import programmerReducer from "./ProgrammeReducer";
import districtReducer from "./DistrictReducer";
import religionReducer from "./ReligionReducer";
import denominationReducer from "./DenominationReducer";
import schoolReducer from "./SchoolReducer";
import shsprogrammerReducer from "./SHSProgrammeReducer";
import yearReducer from "./YearReducer";
import subjectReducer from "./SubjectReducer";
import gradeReducer from "./GradeReducer";
import applicantReducer from "./ApplicantReducer";
const reducers = combineReducers({

    people: userReducer,
    photo:avatarReducer,
    applicationform:formReducer,
    grades:resultReducer,
    programmes:programmerReducer,
    districts:districtReducer,
    religions:religionReducer,
    denomination:denominationReducer,
    school:schoolReducer,
    shsprogramme:shsprogrammerReducer,
    year:yearReducer,
    subject:subjectReducer,
    wasscegrades:gradeReducer,
    applicant:applicantReducer
    
})

export default reducers
