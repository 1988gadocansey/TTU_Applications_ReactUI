import React, { useState, useEffect } from 'react'
import placeholder from "../../placeholder.png"
import {useDispatch, useSelector} from "react-redux";
import {getFormData} from "../../actions/user/UsersAction";
import {previewPhoto, uploadPhoto} from "../../actions/avatars/AvatarsAction";
import Api from "../../utils/api";
/*const defaultImageSrc = placeholder

const initialFieldValues = {
    employeeID: 0,
    employeeName: '',
    occupation: '',
    imageName: '',
    imageSrc: defaultImageSrc,
    imageFile: null
}
/!*const addOrEdit = (formData, onSuccess) => {
    if (formData.get('employeeID') == "0")
        employeeAPI().create(formData)
            .then(res => {
                onSuccess();
                refreshEmployeeList();
            })
            .catch(err => console.log(err))
    else
        employeeAPI().update(formData.get('employeeID'), formData)
            .then(res => {
                onSuccess();
                refreshEmployeeList();
            })
            .catch(err => console.log(err))

}*!/
export default function PictureUpload(props) {
    const user =useSelector((state) => state.photo.UPLOAD_AVATAR);
    const dispatch = useDispatch()

    const { addOrEdit, recordForEdit } = props

    const [values, setValues] = useState(initialFieldValues)
    const [errors, setErrors] = useState({})


    useEffect(() => {
        if (recordForEdit != null)
            setValues(recordForEdit);
    }, [recordForEdit])

    const handleInputChange = e => {
        const { name, value } = e.target;
        setValues({
            ...values,
            [name]: value
        })
    }

    const showPreview = e => {
        if (e.target.files && e.target.files[0]) {
            let imageFile = e.target.files[0];
            const reader = new FileReader();
            reader.onload = x => {
                setValues({
                    ...values,
                    imageFile,
                    imageSrc: x.target.result
                })
            }
            reader.readAsDataURL(imageFile)
        }
        else {
            setValues({
                ...values,
                imageFile: null,
                imageSrc: defaultImageSrc
            })
        }
    }

    const validate = () => {
        let temp = {}

        temp.imageSrc = values.imageSrc !== defaultImageSrc;
        setErrors(temp)
        return Object.values(temp).every(x => x === true)
    }

    const resetForm = () => {
        setValues(initialFieldValues)
        document.getElementById('image-uploader').value = null;
        setErrors({})
    }

    const handleFormSubmit = e => {

        e.preventDefault()
        if (validate()) {
            const formData = new FormData()
            formData.append('employeeID', values.employeeID)
            formData.append('employeeName', values.employeeName)
            formData.append('occupation', values.occupation)
            formData.append('imageName', values.imageName)
            formData.append('imageFile', values.imageFile)
            console.log("data",  formData.get('imageFile'))
        }
    }
    useEffect(uploadPhoto(dispatch,handleFormSubmit),[])

    const applyErrorClass = field => ((field in errors && errors[field] == false) ? ' invalid-field' : '')

    return (
        <>
            <div className="container text-center">
                <p className="lead">Upload Picture</p>
            </div>

            <form autoComplete="off" noValidate onSubmit={handleFormSubmit}>
                <div className="card">
                    <img src={values.imageSrc} className="card-img-top" size={}/>
                    <div className="card-body">
                        <div className="form-group">
                            <input type="file" accept="image/!*" className={"form-control-file" + applyErrorClass('imageSrc')}
                                   onChange={showPreview} id="image-uploader" />
                        </div>
                        <div className="form-group">
                            <input className={"form-control" + applyErrorClass('employeeName')} placeholder="Employee Name" name="employeeName"
                                   value={values.employeeName}
                                   onChange={handleInputChange} />
                        </div>
                        <div className="form-group">
                            <input className="form-control" placeholder="Occupation" name="occupation"
                                   value={values.occupation}
                                   onChange={handleInputChange} />
                        </div>
                        <div className="form-group text-center">
                            <button type="submit" className="ant-btn ant-btn-primary">Submit</button>
                        </div>
                    </div>
                </div>
            </form>

        </>

    )
}*/
