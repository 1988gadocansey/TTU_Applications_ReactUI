import {combineReducers} from "redux";
import userReducer from "./UserReducer";
import avatarReducer from "./AvatarReducer";
import formReducer from "./FormReducer";
import resultReducer from "./ResultReducer";
import programmerReducer from "./ProgrammeReducer";
const reducers = combineReducers({

    people: userReducer,
    photo:avatarReducer,
    applicationform:formReducer,
    grades:resultReducer,
    programmes:programmerReducer
})

export default reducers
