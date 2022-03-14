import React, {useEffect, useState} from 'react'
import {Row, Col, Form, Select, Input, Button, message} from 'antd'
import PropTypes from 'prop-types'
import {useDispatch, useSelector} from "react-redux";
import { useParams} from "react-router";
import { useHistory } from "react-router-dom";
import {updateForm} from "../../actions/forms/FormsAction";
import {getProgrammes} from "../../actions/programmes/ProgrammeActions";
import {getSchool} from "../../actions/schools/SchoolActions";
import {getSHSprogrammes} from "../../actions/shsprogrammes/ShsProgrammeActions";
import {getYears} from "../../actions/years/YearActions";
import {PlusOutlined} from "@ant-design/icons";
 

export default function SecondStep(props) {
    const [loading, setLoading] = useState(false)
    const dispatch = useDispatch()
    const history = useHistory()
    const { id } = useParams()
    const programmes =useSelector((state) => state.programmes.choices);
    useEffect(getProgrammes(dispatch),[])

    const formerSchool =useSelector((state) => state.school.choices);
    useEffect(getSchool(dispatch),[])

    const shsprogramme =useSelector((state) => state.shsprogramme.choices);
    useEffect(getSHSprogrammes(dispatch),[])
    
    const programmeObject = Array.from(programmes)
    const programmeOptions = programmeObject.map((data) =>
         <Select.Option key={data.value}>{data.text} </Select.Option>
    );

    const schoolObject = Array.from(formerSchool)
    const schoolOptions = schoolObject.map((data) =>
         <Select.Option key={data.value}>{data.text} </Select.Option>
    );

    const shsprogrammeObject = Array.from(shsprogramme)
    const shsprogrammeOptions = shsprogrammeObject.map((data) =>
         <Select.Option key={data.value}>{data.text} </Select.Option>
    );
    const getDropList = () => {
        const year = 1990;
        return (
            Array.from( new Array(35), (v,i) =>
                 <Select.Option key={i} value={year+i}>{year+i} </Select.Option>
            )
        );
    };
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
    const saveData = (values) => {
        setLoading(true);
        alert("hi");
         
       // moveToNext()
    }
    const [current, setCurrent] = useState(0)
    return <Row gutter={5}>
        <Col span={8} xs={24} sm={8} md={12}>
            <Form.Item
                initialValue={props.bioData.FormerSchool}
                name="FormerSchool" label="Former School"
                rules={[
                    {
                        required: true,
                        message: 'Required',
                    }
                ]}

            >
                <Select showSearch disabled={props.bioData.completed === 1} placeholder="former school" allowClear>
                     
                    {schoolOptions}
                </Select>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={8} md={12}>
            <Form.Item
                initialValue={props.bioData.ProgrammeStudied}
                name="ProgrammeStudied" label="Programme Studied"
                rules={[
                    {
                        required: true,
                        message: 'Required',
                    }
                ]}

            >
                <Select showSearch disabled={props.bioData.completed === 1} placeholder="programme studied" allowClear>

                    {shsprogrammeOptions}
                </Select>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={8} md={12}>
            <Form.Item
                initialValue={props.bioData.LastYearInSchool}
                name="LastYearInSchool" label="Year Completed"
                rules={[
                    {
                        required: true,
                        message: 'Required',
                    }
                ]}

            >
                <Select showSearch disabled={props.bioData.completed === 1} placeholder="Select Year" allowClear>
                    {getDropList()}
                </Select>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={12} md={12}>
            <Form.Item
                initialValue={props.bioData.EntryMode}
                name="EntryMode" label="Entry Mode" rules={[{ required: true, message: 'Required' }]}>
                <Select disabled={props.bioData.completed === 1} placeholder="Select Mode of study" allowClear>
                     <Select.Option selected={true} value="Regular">Regular </Select.Option>
                     <Select.Option value="Distance">Distance </Select.Option>
                    

                </Select>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={12} md={12}>
            <Form.Item
                initialValue={props.bioData.FirstQualification}
                name="FirstQualification" label="First Qualification" rules={[{ required: true, message: 'Required' }]}>
                <Select disabled={props.bioData.completed === 1} placeholder="First qualification" allowClear>
                     <Select.Option value="WASSSCE">WASSSCE </Select.Option>
                     <Select.Option value="SSCE">SSCE </Select.Option>
                     <Select.Option value="DIPLOMA">DIPLOMA </Select.Option>
                     <Select.Option value="TEU/TECHNICAL CERTIFICATES">TEU/TECHNICAL CERTIFICATES </Select.Option>
                     <Select.Option value="NVTI">NVTI </Select.Option>
                     <Select.Option value="NECO">NECO </Select.Option>
                     <Select.Option value="TEC">TEC </Select.Option>
                </Select>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={12} md={12}>
            <Form.Item
                initialValue={props.bioData.SecondQualification}
                name="SecondQualification" label="Second Qualification">
                <Select disabled={props.bioData.completed === 1} placeholder="Second qualification" allowClear>
                     <Select.Option value="HND">HND </Select.Option>
                     <Select.Option value="BACHELOR">BACHELOR </Select.Option>
                     <Select.Option value="MASTERS">MASTERS </Select.Option>
                     <Select.Option value="PhD">PhD </Select.Option>
                     <Select.Option value="Others">Others </Select.Option>
                </Select>
            </Form.Item>
        </Col>

        <Col span={8} xs={24} sm={8} md={12}>
            <Form.Item
                initialValue={props.bioData.FirstChoice}
                name="FirstChoice" label="First Choice"
                rules={[
                    {
                        required: true,
                        message: 'Required',
                    }
                ]}

            >
                <Select showSearch disabled={props.bioData.completed === 1} placeholder="first choice" allowClear>

                    {programmeOptions}
                </Select>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={8} md={12}>
            <Form.Item
                initialValue={props.bioData.SecondChoiceId}
                name="SecondChoiceId" label="Second Choice"
                rules={[
                    {
                        required: true,
                        message: 'Required',
                    }
                ]}
            >
                <Select showSearch disabled={props.bioData.completed === 1} placeholder="second choice" allowClear>
                    {programmeOptions}
                </Select>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={12} md={12}>
            <Form.Item
                initialValue={props.bioData.SourceOfFinance}

                name="SourceOfFinance"
                label="Source Of Finance"
                rules={[
                    {
                        required: true,
                        message: 'Required',
                    },
                ]}
            >
                <Input disabled={props.bioData.completed === 1}/>
            </Form.Item>
        </Col>
         
       
    </Row>
}

SecondStep.propTypes = {
    bioData: PropTypes.object.isRequired,
    updateForm: PropTypes.func.isRequired
}