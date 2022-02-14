import {useDispatch} from "react-redux";
import Store from '../../utils/Store'
import {Button, Card, Col, Form, Row, Space} from "antd";
import {Upload} from 'antd';
import ImgCrop from 'antd-img-crop';
import {useState} from "react";
import redirect from "react-router-dom/es/Redirect";
import Api from "../../utils/api";


const PictureUpload = () => {
    const state = Store.getState()
    const dispatch = useDispatch()
    const [form] = Form.useForm()
    const [fileList, setFileList] = useState([
      
    ]);
    const onChange = ({fileList: newFileList}) => {
        setFileList(newFileList);
    };

    const onPreview = async file => {
        let src = file.url;
        if (!src) {
            src = await new Promise(resolve => {
                const reader = new FileReader();
                reader.readAsDataURL(file.originFileObj);
                reader.onload = () => resolve(reader.result);
            });
        }
        const image = new Image();
        image.src = src;
        const imgWindow = window.open(src);
        imgWindow.document.write(image.outerHTML);
    };
    
    const submit = async (e) => {
        e.preventDefault();
        alert("hello");
        await Api().post('/Upload', {});


    }
    if (redirect) {
      
    }
    return (
        <Row justify="center" align="middle">
            <Col span={8} sm={24} xs={24} md={8}>
                <Card bordered={false} title="Upload a Profile Picture">
                    <div align={'center'}>
                        <form onSubmit={submit}>
                              <ImgCrop rotate>
                            <Upload
                                action="https://www.mocky.io/v2/5cc8019d300000980a055e76"
                                listType="picture-card"
                                fileList={fileList}
                                onChange={onChange}
                                onPreview={onPreview}
                            >
                                {fileList.length < 5 && '+ Upload'}
                            </Upload>
                        </ImgCrop> 


                            <button className="btn btn-outline-secondary">Upload</button>
                        </form>

                    </div>
                </Card>
            </Col>
        </Row>


    )
}
export default PictureUpload
