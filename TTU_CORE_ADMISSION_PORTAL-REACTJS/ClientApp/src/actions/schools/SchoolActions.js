import { Types } from './Types'
import API from "../../utils/api";
export const  getSchool = (dispatch) => async () => {
    await API.get('/api/selectbox/schools')
        .then((res) => {
            dispatch({
                type: Types.GET_SCHOOL,
                payload: res.data
            })

        }).catch((err) => {
            console.log("error",err)
        })
    

}
 