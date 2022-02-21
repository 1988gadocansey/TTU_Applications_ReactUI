import React from "react";
import {Upload, message, Col, Row, Card, Button, Modal} from 'antd';
import Icon, {AlignCenterOutlined, LoadingOutlined, PlusOutlined} from '@ant-design/icons';
import axios from "axios";
import Api from "../../utils/api";
import {uploadPhoto} from "../../actions/avatars/AvatarsAction";
import {connect} from "react-redux";


class PictureUpload extends React.Component {
    state = {
        previewVisible: false,
        previewImage: "",
        fileList: []
    };


    beforeUpload = file => {
        const isJpgOrPng = file.type === 'image/jpeg' || file.type === 'image/jpg';
        if (!isJpgOrPng) {
            message.error('You can only upload JPG/JPEG file!');
        }
        const isLt2M = file.size / 1024 / 1024 < 2;
        if (!isLt2M) {
            message.error('Image must smaller than 2MB!');
        }
        return isJpgOrPng && isLt2M;
    }
    handleCancel = () => this.setState({previewVisible: false});

    handlePreview = file => {
        this.setState({
            previewImage: file.thumbUrl,
            previewVisible: true
        });
    };

    handleUpload = ({fileList}) => {
        //---------------^^^^^----------------
        // this is equivalent to your "const img = event.target.files[0]"
        // here, antd is giving you an array of files, just like event.target.files
        // but the structure is a bit different that the original file
        // the original file is located at the `originFileObj` key of each of this files
        // so `event.target.files[0]` is actually fileList[0].originFileObj
        console.log('fileList', fileList);

        // you store them in state, so that you can make a http req with them later
        this.setState({fileList});
    };

    handleSubmit = event => {
        event.preventDefault();

        let formData = new FormData();
        // add one or more of your files in FormData
        // again, the original file is located at the `originFileObj` key
        formData.append("file", this.state.fileList[0].originFileObj);

       /* Api.post("applicationform", formData)
            .then(res => {
                console.log("res", res);
                message.success('Picture Uploaded'+res.toString());
            })
            .catch(err => {
                console.log("err", err);
                message.error(err);
            });*/
        this.props.uploadPhoto(formData)   // dispatches actions to add uploadPhoto function
        uploadPhoto()
    };

    render() {
        const {previewVisible, previewImage, fileList} = this.state;
        const uploadButton = (
            <div>
                <Icon type="plus"/>
                <div className="ant-upload-text">Click to select photo</div>
            </div>
        );
        return (
            <div>
                <center> <div style={{marginTop: 8}}>Upload Passport Photo</div></center>
                <Row style={{marginBottom: 5}} justify="space-between" align="middle">
                    <Col span={24}>
                        <form autoComplete="off" noValidate>
                            <Card bordered={false}>

                                <center>

                                    <Upload
                                        listType="picture-card"
                                        fileList={fileList}

                                        className="avatar-uploader"

                                        onPreview={this.handlePreview}
                                        onChange={this.handleUpload}
                                        beforeUpload={()=>false}
                                        name="photo"
                                        accept="image/jpeg"
                                        
                                    >
                                        {fileList.length == 1 ? null : uploadButton}
                                      
                                    </Upload>


                                    <Modal
                                        visible={previewVisible}
                                        footer={null}
                                        onCancel={this.handleCancel}
                                    >
                                        <img alt="example" style={{width: "100%"}} src={previewImage}/>
                                    </Modal></center>
                            </Card>
                            <p></p>
                            <center><Button className="ant-btn ant-btn-primary" onClick={this.handleSubmit}>Submit</Button></center>

                        </form>
                    </Col>
                </Row>
            </div>
        );
    }
}
export default connect(null, { uploadPhoto })(PictureUpload)
 