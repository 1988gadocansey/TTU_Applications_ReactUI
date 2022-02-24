import React, {useState} from 'react'
import moment from 'moment'
import { Row, Col, Form, Input, Select, DatePicker, InputNumber } from 'antd'
import { nationalities, regions, faculties } from '../../utils/nationalities'
import PropTypes from 'prop-types'
import {useDispatch} from "react-redux";
import { useParams} from "react-router";
import { useHistory } from "react-router-dom";
import {updateForm} from "../../actions/forms/FormsAction";
export default function FirstStep(props) {
    const [loading, setLoading] = useState(false)
    const dispatch = useDispatch()
    const history = useHistory()
    const { id } = useParams()
    const [current, setCurrent] = useState(0)
    return <Row gutter={5}>
        <Col span={8} xs={24} sm={8} md={8}>
            <Form.Item
                initialValue={props.bioData.title}
                name="title" label="Title" rules={[{ required: true, message: 'Required' }]}>
                <Select disabled={props.bioData.completed === 1} placeholder="Select Title" allowClear>
                    <Select.Option value="Mr.">Mr</Select.Option>
                    <Select.Option value="Mrs.">Mrs</Select.Option>
                    <Select.Option value="Miss">Miss</Select.Option>
                    <Select.Option value="Madam">Madam</Select.Option>
                    <Select.Option value="Prof.">Prof</Select.Option>
                    <Select.Option value="Dr.">Dr</Select.Option>
                </Select>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={12} md={8}>
            <Form.Item
                initialValue={props.bioData.surName}
                name={'surName'}
                label="Surname"
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
        <Col span={8} xs={24} sm={12} md={8}>
            <Form.Item
                initialValue={props.bioData.otherNames}
                name={'otherNames'}
                label="Other Names"
                rules={[
                    {
                        required: true,
                        message: 'Required',
                    }
                ]}>
                <Input disabled={props.bioData.completed === 1}/>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={8} md={8}>
            <Form.Item
                initialValue={props.bioData.gender}
                name="gender" label="Gender">
                <Select showSearch disabled={props.bioData.completed === 1} placeholder="Select Gender" allowClear>
                    <Select.Option value="Male">Male</Select.Option>
                    <Select.Option value="Female">Female</Select.Option>
                </Select>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={12} md={8}>
            <Form.Item
                initialValue={props.bioData.dateOfBirth != null && moment(props.bioData.dateOfBirth, 'YYYY-MM-DD')}
                name="dateOfBirth"
                label="Date of Birth"
                /* rules={[
                  {
                    type: 'object',
                    required: true,
                    message: 'Required',
                  }
                ]} */>
                <DatePicker disabled={props.bioData.completed === 1} style={{ width: '100%' }} format={'YYYY-MM-DD'}/>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={12} md={8}>
            <Form.Item
                initialValue={props.bioData.placeOfBirth}
                name={'placeOfBirth'}
                label="Place Of Birth"
                /* rules={[
                  {
                    required: true,
                    message: 'Required',
                  },
                ]} */
            >
                <Input disabled={props.bioData.completed === 1}/>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={8} md={8}>
            <Form.Item
                initialValue={props.bioData.nationality}
                name="nationality" label="Nationality"
                /* rules={[{ required: true, message: 'Required' }]} */
            >
                <Select disabled={props.bioData.completed === 1} placeholder="Select Nationality" allowClear showSearch>
                    {
                        nationalities.map((nationality) => {
                            return Object.keys(nationality).map((initial, index) => {
                                return (
                                    <Select.OptGroup key={initial} label={initial}>
                                        {
                                            Object.keys(nationality[initial]).map((country, countryIndex) => {
                                                return (
                                                    <Select.Option key={country + initial} value={nationality[initial][country]}>
                                                        {nationality[initial][country]}
                                                    </Select.Option>
                                                )
                                            })
                                        }
                                    </Select.OptGroup>
                                )
                            })
                        })
                    }
                </Select>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={12} md={8}>
            <Form.Item
                initialValue={props.bioData.homeTown}
                name={'homeTown'}
                label="Home Town"
                /* rules={[
                  {
                    required: true,
                    message: 'Required',
                  },
                ]} */
            >
                <Input disabled={props.bioData.completed === 1}/>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={8} md={8}>
            <Form.Item initialValue={props.bioData.region} name="region" label="Region"
                /* rules={[{ required: true, message: 'Required' }]} */
            >
                <Select disabled={props.bioData.completed === 1} placeholder="Select Region" allowClear showSearch>
                    {
                        regions.map((region) => {
                            return (
                                <Select.Option key={region} value={region}>
                                    {region}
                                </Select.Option>
                            )
                        })
                    }
                </Select>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={12} md={8}>
            <Form.Item
                initialValue={props.bioData.telephone}
                name={'telephone'}
                label="Phone Number"
                /* rules={[
                  {
                    required: true,
                    message: 'Required',
                  },
                ]} */
            >
                <Input disabled={props.bioData.completed === 1}/>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={12} md={8}>
            <Form.Item
                initialValue={props.bioData.email}
                name="email"
                label="E-mail"
                rules={[
                    {
                        type: 'email',
                        message: 'Not valid E-mail!',
                    },
                    /* {
                      required: true,
                      message: 'Required',
                    }, */
                ]}
            >
                <Input disabled={props.bioData.completed === 1}/>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={8} md={8}>
            <Form.Item initialValue={props.bioData.faculty} name="faculty" label="Faculty"
                /* rules={[{ required: true, message: 'Required' }]} */
            >
                <Select disabled={props.bioData.completed === 1} placeholder="Select Faculty" allowClear showSearch>
                    {
                        faculties.map((faculty) => {
                            return (
                                <Select.Option key={faculty} value={faculty}>
                                    {faculty}
                                </Select.Option>
                            )
                        })
                    }
                </Select>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={12} md={8}>
            <Form.Item
                initialValue={props.bioData.programme}

                name="programme"
                label="Programme"
                /* rules={[
                  {
                    required: true,
                    message: 'Required',
                  },
                ]} */
            >
                <Input disabled={props.bioData.completed === 1}/>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={12} md={8}>
            <Form.Item
                initialValue={props.bioData.cgpa}
                name="cgpa"
                label="CGPA"
                /* rules={[{
                  required: true,
                  message: 'Enter a valid CGPA'
                }]} */
            >
                <InputNumber max={5} style={{ width: '100%' }} disabled={props.bioData.completed === 1}/>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={12} md={8}>
            <Form.Item
                initialValue={props.bioData.year}

                name="year"
                label="Year"
                /* rules={[
                  {
                    required: true,
                    message: 'Required',
                  },
                ]} */
            >
                <InputNumber min={1990} max={new Date().getFullYear()} disabled={props.bioData.completed === 1}/>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={12} md={8}>
            <Form.Item
                initialValue={props.bioData.indexNumber}
                name="indexNumber"
                label="Index Number"
                /* rules={[
                  {
                    required: true,
                    message: 'Required',
                  },
                ]} */
            >
                <Input disabled={props.bioData.completed === 1}/>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={12} md={8}>
            <Form.Item
                initialValue={props.bioData.hall}
                name="hall"
                label="Hall"
                /* rules={[
                  {
                    required: true,
                    message: 'Required',
                  },
                ]} */
            >
                <Select showSearch disabled={props.bioData.completed === 1} placeholder="Select Hall" allowClear>
                    <Select.Option value="Ahanta">Ahanta</Select.Option>
                    <Select.Option value="Nzema">Nzema</Select.Option>
                    <Select.Option value="GetFund">GetFund</Select.Option>
                    <Select.Option value="GHACEM">GHACEM</Select.Option>
                    <Select.Option value="University Hall">University Hall</Select.Option>
                </Select>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={12} md={8}>
            <Form.Item
                initialValue={props.bioData.formerInstitution}
                name="formerInstitution"
                label="Former Institution"
                /* rules={[
                  {
                    required: true,
                    message: 'Required',
                  },
                ]} */
            >
                <Input disabled={props.bioData.completed === 1}/>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={12} md={8}>
            <Form.Item
                initialValue={props.bioData.previousPosition}
                name="previousPosition"
                label="Previous Position in TTU"
            >
                <Input.TextArea disabled={props.bioData.completed === 1}/>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={12} md={8}>

            <Form.Item
                initialValue={props.bioData.formerPosition}
                name="formerPosition"
                label="Position(s) held in Former Institution"
            >
                <Input.TextArea disabled={props.bioData.completed === 1}/>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={12} md={8}>
            <Form.Item
                initialValue={props.bioData.homeAddress}
                name="homeAddress"
                label="Home Address"
                /* rules={[
                  {
                    required: true,
                    message: 'Required',
                  },
                ]} */
            >
                <Input.TextArea disabled={props.bioData.completed === 1}/>
            </Form.Item>
        </Col>
    </Row>
}
 
FirstStep.propTypes = {
    bioData: PropTypes.object.isRequired,
    updateForm: PropTypes.func.isRequired
}