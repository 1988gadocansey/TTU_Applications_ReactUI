import { Types } from './Types'
import API from "../../utils/api";
export const  getSHSprogrammes = (dispatch) => async () => {
    await API.get('/api/selectbox/shsprogrammes')
        .then((res) => {
            dispatch({
                type: Types.GET_SHSPROGRAMME,
                payload: res.data
            })

        }).catch((err) => {
            console.log("error",err)
        })
    

}
 