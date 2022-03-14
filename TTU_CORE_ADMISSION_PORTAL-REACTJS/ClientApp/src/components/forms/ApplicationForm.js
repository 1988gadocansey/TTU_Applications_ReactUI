import {Steps, Button, message, Divider, Row, Form, Col, Space, Tag, Input, Popconfirm} from 'antd';
import BiodataContainer from "../../containers/BiodataContainer";
import React, {useState} from "react";
import AcademicContainer from "../../containers/AcademicContainer";
import PropTypes from "prop-types";
import {useMediaQuery} from "react-responsive";
import {useDispatch} from "react-redux";
import {useHistory} from "react-router-dom";
import {useParams} from "react-router";
import {addForm, updateForm} from "../../actions/forms/FormsAction";
import FormSide from "./form-side";

const {Step} = Steps;

const steps = [
    {
        title: 'Biodata',
        content: <BiodataContainer/>,

    },
    {
        title: 'Academic',
        content: <AcademicContainer/>,
    },


];

export default function ApplicationForm(props) {

    const [current, setCurrent] = React.useState(0);
    const dispatch = useDispatch()
    const history = useHistory()
    const { id } = useParams()
    const [loading, setLoading] = useState(false)

    const [form] = Form.useForm()
    const next = () => {

        //console.log("programmes"+JSON.stringify(programmes))
        form.setFields([
            {
                name: 'completed',
                value: 1
            }
        ])
        setCurrent(current + 1)
    }

    const prev = () => {
        setLoading(true)
        form.setFields([
            {
                name: 'completed',
                value: 0
            }
        ])
        submit(form.getFieldsValue())
        setCurrent(current - 1)
    }
    const moveToNext = () => {
        if (loading === false) {
            if (current !== steps.length - 1) { next() }
        }
    }

    const saveData = (values) => {
        setLoading(true)
        submit(form.getFieldsValue()).then(() =>console.log(form.getFieldsValue()))
        alert("finish");
        //moveToNext()
    }
    const onChange = (current) => {
        setLoading(true)
        form.setFields([
            {
                name: 'completed',
                value: current === steps.length - 1 ? 1 : 0
            }
        ])
        submit(form.getFieldsValue())
        setCurrent(current)
    }
    const submit = async (values) => {
        
            values.id = id
            let newValue = {}
            if (values.dateOfBirth) {
                newValue = { ...values, dateOfBirth: values.dateOfBirth.format('YYYY-MM-DD') }
            } else {
                newValue = { ...values }
            }
            await dispatch(addForm(newValue)).then((res) => {
                message.success('Data Saved')
                setLoading(false)
            }).catch((e) => {
                console.log(e)
                message.warning('Could not save data! Make sure required fields have value')
            })
       
        setLoading(false)
    }
    function completeForm () {
        setLoading(true)
        submit(form.getFieldsValue()).then(r => history.push('/nominees'))
        // history.push('/nominees')
    }
    return (
        <>

            <Steps current={current}>
                {steps.map(item => (
                    <Step key={item.title} title={item.title} />
                ))}
            </Steps>
            <p></p>
            <div className="ant-card">
                <div className="ant-card-body">
                    {
                        props.bioData.completed === 1 &&
                        <Space>
                            <Tag color="red"> Form is completed! Print Now</Tag>
                            {/*<Index bioData={props.bioData} iconSize={20}/>*/}
                            <p>Preview and print</p>
                        </Space>
                    }
                    <Form form={form} layout="horizontal" initialValues={{ }} onFinish={saveData}>

                        <mark>Fields marked in red asteriks(*) are required.</mark>
                        <Row gutter={5} justify={'center'}>
                            
                            <div className="steps-content">{steps[current].content}</div>
                            <div className="steps-action">
                                {current < steps.length - 1 && (
                                    <Button  type="primary"  onClick={()=>next()}htmlType={'submit'}>
                                        Next
                                    </Button>
                                )}
                                {current === steps.length - 1 && (
                                    <Button htmlType={'submit'} type="primary"   onClick={()=>saveData()}>
                                        Done
                                    </Button>
                                )}
                                {current > 0 && (
                                    <Button style={{margin: '0 8px'}} onClick={() => prev()}>
                                        Previous
                                    </Button>
                                )}
                                {
                                    props.bioData.completed === 0 &&
                                    <>
                                        {current === steps.length - 1 && (
                                            <Col span={3} xs={24} md={3} sm={3} lg={3}>
                                                <Form.Item hidden initialValue={1} name={'completed'}>
                                                    <Input/>
                                                </Form.Item>
                                                <Popconfirm
                                                    title="You cannot edit after submitting, Continue?"
                                                    onConfirm={() => completeForm()}
                                                    okText="Yes! Continue"
                                                    cancelText="No! Cancel"
                                                >
                                                    <Button htmlType={'submit'} type="primary">
                                                        Finish
                                                    </Button>

                                                </Popconfirm>
                                            </Col>
                                        )}
                                    </>
                                }

                            </div>
                        </Row>
                    </Form>
                </div>
            </div>
        </>
    );
};
ApplicationForm.propTypes = {

    bioData: PropTypes.object.isRequired,
    setFormData: PropTypes.func.isRequired,
    updateForm: PropTypes.func.isRequired
}