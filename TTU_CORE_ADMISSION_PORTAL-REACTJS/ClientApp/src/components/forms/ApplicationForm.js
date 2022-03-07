import React, {useEffect, useState} from 'react'
import {
    Button,
    Form,
    Card,
    Col,
    Row,
    Spin,
    Popconfirm,
    Input,
    Space,
    Tag, message, Steps
} from 'antd'
import FormSide from './form-side'
import PropTypes from 'prop-types'
import {useDispatch, useSelector} from 'react-redux'
import {   useParams } from 'react-router'
import { useHistory } from "react-router-dom";
import BiodataContainer from "../../containers/BiodataContainer";
import SecondStep from "./SecondStep";
import ThirdStep from "./ThirdStep";
import {updateForm} from "../../actions/forms/FormsAction";
import {getFormData} from "../../actions/user/UsersAction";
import {getProgrammes} from "../../actions/programmes/ProgrammeActions";
import AcademicContainer from "../../containers/AcademicContainer";
const {Step} = Steps;

const steps = [
    {
        title: 'Biodata',
        content: <BiodataContainer />,

    },
    {
        title: 'Academic',
        content: <AcademicContainer/>,
        // icon:<AcUnit />
    }
   /* {
        title: 'Results',
        content: <ThirdStep/>
    },*/
];
export default function ApplicationForm (props) {
    const [loading, setLoading] = useState(false)
    const dispatch = useDispatch()
    const history = useHistory()
    const { id } = useParams()
   
    const [current, setCurrent] = useState(0)
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
    const submit = async (values) => {
        if (props.bioData.completed === 0) {
            values.id = id
            let newValue = {}
            if (values.dateOfBirth) {
                newValue = { ...values, dateOfBirth: values.dateOfBirth.format('YYYY-MM-DD') }
            } else {
                newValue = { ...values }
            }
            await dispatch(updateForm(newValue)).then((res) => {
                message.success('Data Saved')
                setLoading(false)
            }).catch((e) => {
                console.log(e)
                message.warning('Could not save data! Make sure required fields have value')
            })
        }
        setLoading(false)
    }

    const moveToNext = () => {
        if (loading === false) {
            if (current !== steps.length - 1) { next() }
        }
    }

    const saveData = (values) => {
        setLoading(true)
        submit(values)
        moveToNext()
    }

    const continueLater = () => {
        setLoading(true)
        form.setFields([
            {
                name: 'completed',
                value: 0
            }
        ])
        submit(form.getFieldsValue()).then(r => history.push('/nominees'))
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

    function completeForm () {
        setLoading(true)
        submit(form.getFieldsValue()).then(r => history.push('/applicants'))
        // history.push('/nominees')
    }

    return (
        <div className="ant-card">
            <div className="ant-card-body">
                <mark>Fields marked in red asteriks(*) are required.</mark>
        <Row gutter={5} justify={'center'} align={'center'}>
            <Col span={4} lg={4} md={4} sm={24} xs={24}>
                <FormSide
                    onChange={onChange}
                    steps={steps}
                    current={current}
                    portfolio={props.bioData.name}
                    imageUrl={props.bioData.file}
                    indexNumber={props.bioData.indexNumber}
                    completed={props.bioData.completed}
                />
            </Col>
            <Col span={16} lg={16} md={16} sm={24} xs={24}>
                {
                    props.bioData.completed === 1 &&
                    <Space>
                        <Tag color="red"> Form is completed! Print Now</Tag>
                        {/*<Index bioData={props.bioData} iconSize={20}/>*/}
                        <p>Preview and print</p>
                    </Space>
                }
                <Spin spinning={loading} tip={'Saving Data'}>
                    <Form form={form} layout="horizontal" initialValues={{ }} onFinish={saveData}>
                        <Card bordered={false} title={steps[current].title}>
                            <div className="steps-contents" >
                                {steps[current].content}
                            </div>
                            <Row gutter={[3, 3]} className="steps-action">
                                {current < steps.length - 1 && (
                                    <Col span={8} xs={24} md={4} sm={4} lg={3}>
                                        <Button htmlType={'submit'} type="primary" >
                                            Next
                                        </Button>
                                    </Col>
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
                                {current > 0 && (
                                    <Col span={3} xs={24} md={3} sm={3} lg={3}>
                                        <Button onClick={() => prev()}>
                                            Previous
                                        </Button>
                                    </Col>
                                )}
                                {
                                    props.bioData.completed === 0 &&
                                    <Col span={3} xs={24} md={3} sm={3} lg={3}>
                                        <Button type={'dashed'} onClick={() => continueLater()}>
                                            Continue Later
                                        </Button>
                                    </Col>
                                }
                            </Row>
                        </Card>
                    </Form>
                </Spin>
            </Col>
        </Row>
            </div>
        </div>
    )
}
ApplicationForm.propTypes = {

    bioData: PropTypes.object.isRequired,
    setFormData: PropTypes.func.isRequired,
    updateForm: PropTypes.func.isRequired
}
