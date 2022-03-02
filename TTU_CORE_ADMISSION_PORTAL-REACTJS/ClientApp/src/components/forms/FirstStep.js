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
                initialValue={props.bioData.LastName}
                name={'LastName'}
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
                initialValue={props.bioData.FirstName}
                name={'FirstName'}
                label="First Name"
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
                name={'OtherNames'}
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
                initialValue={props.bioData.Gender}
                name="Gender" label="Gender"
                rules={[
                    {
                        required: true,
                        message: 'Required',
                    }
                ]}
            
            >
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
                 rules={[
                  {
                    type: 'object',
                    required: true,
                    message: 'Required',
                  }
                ]} >
                <DatePicker disabled={props.bioData.completed === 1} style={{ width: '100%' }} format={'YYYY-MM-DD'}/>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={12} md={8}>
            <Form.Item
                initialValue={props.bioData.Title}
                name="Title" label="Title" rules={[{ required: true, message: 'Required' }]}>
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
        <Col span={8} xs={24} sm={8} md={8}>
            <Form.Item
                initialValue={props.bioData.Gender}
                name="MaritalStatus" label="Marital"
                rules={[
                    {
                        required: true,
                        message: 'Required',
                    }
                ]}

            >
                <Select showSearch disabled={props.bioData.completed === 1} placeholder="Select status" allowClear>
                    <Select.Option selected={true} value="Single">Single</Select.Option>
                    <Select.Option value="Married">Married</Select.Option>
                </Select>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={12} md={8}>
            <Form.Item
                initialValue={props.bioData.dateOfBirth != null && moment(props.bioData.dateOfBirth, 'YYYY-MM-DD')}
                name="dateOfBirth"
                label="Date of Birth"
                rules={[
                    {
                        type: 'object',
                        required: true,
                        message: 'Required',
                    }
                ]} >
                <DatePicker disabled={props.bioData.completed === 1} style={{ width: '100%' }} format={'YYYY-MM-DD'}/>
            </Form.Item>
        </Col>

        <Col span={8} xs={24} sm={12} md={8}>
            <Form.Item
                initialValue={props.bioData.PostGPRS}
                name={'PostGPRS'}
                label="Post GPRS"
            >
                <Input disabled={props.bioData.Completed === 1}/>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={12} md={8}>
            <Form.Item
                initialValue={props.bioData.Phone}
                name={'Phone'}
                label="Phone Number"
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
            initialValue={props.bioData.EmergencyPhone}
            name={'EmergencyPhone'}
            label="Alt Phone"
           
        >
            <Input disabled={props.bioData.completed === 1}/>
        </Form.Item>
    </Col>
        <Col span={8} xs={24} sm={12} md={8}>
            <Form.Item
                initialValue={props.bioData.Email}
                name="Email"
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
        <Col span={8} xs={24} sm={12} md={8}>
            <Form.Item
                initialValue={props.bioData.HomeTown}

                name="HomeTown"
                label="Hometown"
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
                initialValue={props.bioData.Address}

                name="Address"
                label="Address"
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
        <Col span={8} xs={24} sm={8} md={8}>
            <Form.Item
                initialValue={props.bioData.Awaiting}
                name="Awaiting" label="Awaiting"
                rules={[
                    {
                        required: true,
                        message: 'Required',
                    }
                ]}

            >
                <Select showSearch disabled={props.bioData.completed === 1} placeholder="Select status" allowClear>
                    <Select.Option selected={true} value="false">No</Select.Option>
                    <Select.Option value="true">Yes</Select.Option>
                </Select>
            </Form.Item>
        </Col>
        <Col span={8} xs={24} sm={8} md={8}>
            <Form.Item
                initialValue={props.bioData.Nationality}
                name="Nationality" label="Country"
                 rules={[{ required: false, message: 'Required' }]} 
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
        <Col span={8} xs={24} sm={8} md={8}>
            <Form.Item initialValue={props.bioData.Region} name="region" label="Region"
                 rules={[{ required: true, message: 'Required' }]} 
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
        <Col span={8} xs={24} sm={8} md={8}>
            <Form.Item initialValue={props.bioData.District} name="District" label="District"
                       rules={[{ required: true, message: 'Required' }]}
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