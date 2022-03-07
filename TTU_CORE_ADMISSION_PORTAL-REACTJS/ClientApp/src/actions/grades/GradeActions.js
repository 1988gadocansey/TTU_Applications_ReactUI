import { Types } from './Types'
import API from "../../utils/api";
export const  getGrades = (dispatch) => async () => {
    await API.get('/api/selectbox/grades')
        .then((res) => {
            dispatch({
                type: Types.GET_GRADE,
                payload: res.data
            })

        }).catch((err) => {
            console.log("error",err)
        })
    

}


 
 