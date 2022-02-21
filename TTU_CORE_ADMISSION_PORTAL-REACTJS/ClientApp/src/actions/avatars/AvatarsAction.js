import { Types } from './Types'
import API from "../../utils/api";
export const  uploadPhoto = (dispatch,photo) => async () => {
    await API.get('/applicationform')
        .then((res) => {
            dispatch({
                type: Types.UPLOAD_AVATAR,
                payload: photo
            })

        }).catch((err) => {
            console.log("error",err)
        })

}
export const  previewPhoto = (applicationNumber,dispatch) => async () => {
    await dispatch({
                type: Types.SHOW_AVATAR,
                payload: "https://photos.ttuportal.com/public/albums/thumbnails/"+ applicationNumber+".jpg"
            })
}