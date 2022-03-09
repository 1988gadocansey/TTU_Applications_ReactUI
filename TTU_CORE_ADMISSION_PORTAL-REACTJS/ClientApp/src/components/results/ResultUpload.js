import {Form, Input, Button, Space, Select, Col, Row} from 'antd';
import {MinusCircleOutlined, PlusOutlined} from '@ant-design/icons';
import {Table, Tag} from 'antd';
import {useDispatch, useSelector} from "react-redux";
import React, {useEffect} from "react";
import {getSubject} from "../../actions/subjects/SubjectActions";
import {getGrades} from "../../actions/grades/GradeActions";

const ResultUpload = () => {
    const years = () => {
        const year = 1990;
        return (
            Array.from( new Array(35), (v,i) =>
                <Select.Option key={i} value={year+i}>{year+i} </Select.Option>
            )
        );
    };
    const dispatch = useDispatch()
    const subjects = useSelector((state) => state.subject.choices);
    useEffect(getSubject(dispatch), [])


    const grades = useSelector((state) => state.wasscegrades.choices);
    useEffect(getGrades(dispatch), [])


    const subjectObject = Array.from(subjects)
    const subjectOptions = subjectObject.map((data) =>
        <Select.Option key={data.value}>{data.text} </Select.Option>
    );

    const gradeObject = Array.from(grades)
    const gradeOptions = gradeObject.map((data) =>
        <Select.Option key={data.value}>{data.text} </Select.Option>
    );

    const onFinish = values => {
        console.log('Received values of form:', values);
    };

    const dataSource = [
        {key: '1', username: 'Gourav', age: 10},
        {key: '2', username: 'Kartik', age: 20},
        {key: '3', username: 'Madhu', age: 30},
        {key: '4', username: 'Karu', age: 40},
        {key: '5', username: 'Dinesh', age: 50},
    ];

    // Sample Columns data
    const columns = [
        {
            title: 'Username',
            dataIndex: 'username',
            key: 'username',
        },
        {
            title: 'Age',
            dataIndex: 'age',
            key: 'age',
        },
    ];
    return (
        <>
            <div className="ant-col ant-col-24">
                <div className="ant-card">
                    <div className="ant-card-body">
                        <Form name="dynamic_form_nest_item" onFinish={onFinish} autoComplete="off">
                            <Form.List name="users">
                                {(fields, {add, remove}) => (
                                    <>
                                        {fields.map(({key, name, ...restField}) => (
                                            <Space key={key} style={{display: 'flex', marginBottom: 8}}
                                                   align="baseline">
                                                <Row gutter={5}>
                                                    <Col span={8} xs={24} sm={8} md={4}>
                                                        <Form.Item
                                                            name={'IndexNo'}
                                                            label="IndexNo"
                                                            rules={[
                                                                {
                                                                    required: true,
                                                                    message: 'Required',
                                                                },
                                                            ]}
                                                        >
                                                            <Input/>
                                                        </Form.Item>
                                                    </Col>
                                                    <Col span={8} xs={24} sm={8} md={4}>
                                                        <Form.Item
                                                            name={'Center'}
                                                            label="Center"
                                                            id="Center"
                                                            rules={[
                                                                {
                                                                    required: true,
                                                                    message: 'Required',
                                                                },
                                                            ]}
                                                        >
                                                            <Input/>
                                                        </Form.Item>
                                                    </Col>
                                                    <Col span={8} xs={24} sm={8} md={8}>
                                                        <Form.Item
                                                            name="ExamType" id="ExamType" label="Exam Type"
                                                            rules={[{required: true, message: 'Required'}]}>
                                                            <Select placeholder="exams" allowClear>
                                                                <Select.Option selected={true}
                                                                               value="WASSCE">WASSCE </Select.Option>
                                                                <Select.Option value="SSSCE">SSSCE </Select.Option>
                                                                <Select.Option value="TEU">TEU </Select.Option>
                                                                <Select.Option value="ABCE">ABCE </Select.Option>
                                                                <Select.Option value="Certificate I">Certificate
                                                                    I </Select.Option>
                                                                <Select.Option value="Certificate II">Certificate
                                                                    II </Select.Option>
                                                                <Select.Option value="Foundation Certificate">Foundation
                                                                    Certificate </Select.Option>
                                                                <Select.Option value="GCE A LEVEL">GCE A
                                                                    LEVEL </Select.Option>
                                                                <Select.Option value="GCE O LEVEL">GCE O
                                                                    LEVEL </Select.Option>
                                                                <Select.Option value="JAMB">JAMB </Select.Option>
                                                                <Select.Option value="Level I (Certificate)">Level I
                                                                    (Certificate) </Select.Option>
                                                                <Select.Option value="Level II (Higher Certificate)">Level
                                                                    II (Higher Certificate) </Select.Option>
                                                                <Select.Option value="Level III (Diploma Certificate)">Level
                                                                    III (Diploma Certificate) </Select.Option>
                                                                <Select.Option value="Level IV (Advanced Diploma)">Level
                                                                    IV (Advanced Diploma) </Select.Option>
                                                                <Select.Option value="NABPTEX">NABPTEX </Select.Option>
                                                                <Select.Option value="NECO">NECO </Select.Option>
                                                                <Select.Option value="NVTI">NVTI </Select.Option>
                                                                <Select.Option value="Proficiency I">Proficiency
                                                                    I </Select.Option>
                                                                <Select.Option value="Proficiency II">Proficiency
                                                                    II </Select.Option>

                                                            </Select>
                                                        </Form.Item>
                                                    </Col>
                                                    <Col span={8} xs={24} sm={8} md={8}>
                                                        <Form.Item
                                                            
                                                            name="Subject" id="Subject" label="Subjects"
                                                            rules={[{required: true, message: 'Required'}]}>
                                                            <Select placeholder="subject types" allowClear>
                                                                {subjectOptions}
                                                            </Select>
                                                        </Form.Item>
                                                    </Col>
                                                    <Col span={8} xs={24} sm={8} md={4}>
                                                        <Form.Item
                                                            name="Grade" id="Grades" label="Grades"
                                                            rules={[{required: true, message: 'Required'}]}>
                                                            <Select placeholder="grades" allowClear>
                                                                {gradeOptions}
                                                            </Select>
                                                        </Form.Item>
                                                    </Col>
                                                    <Col span={8} xs={24} sm={8} md={4}>
                                                        <Form.Item
                                                            name="Sitting" id="Sitting" label="Sitting"
                                                            rules={[{required: true, message: 'Required'}]}>
                                                            <Select placeholder="sitting" allowClear>
                                                                <option value="1">Ist</option>
                                                                <option value="2">2nd</option>
                                                                <option value="3">3rd</option>
                                                                <option value="4">4th</option>
                                                            </Select>
                                                        </Form.Item>
                                                    </Col>
                                                    <Col span={8} xs={24} sm={8} md={6}>
                                                        <Form.Item
                                                            name="Month" id="Month" label="Month of Exam"
                                                            rules={[{required: true, message: 'Required'}]}>
                                                            <Select placeholder="months" allowClear>
                                                                <option value="May/June">May/June</option>
                                                                <option value="Nov/Dec">Nov/Dec</option>
                                                                <option value="December">December</option>
                                                                <option value="March">March</option>
                                                                <option value="May">May</option>
                                                                <option value="June">June</option>
                                                                <option value="September">September</option>
                                                                <option value="Other">Other</option>
                                                            </Select>
                                                        </Form.Item>
                                                    </Col>
                                                    <Col span={8} xs={24} sm={8} md={8}>
                                                        <Form.Item
                                                            name="Year" id="Year" label="Year of Exam"
                                                            rules={[{required: true, message: 'Required'}]}>
                                                            <Select placeholder="year of exams" allowClear>
                                                                {years()}
                                                            </Select>
                                                        </Form.Item>
                                                    </Col>
                                                    <MinusCircleOutlined onClick={() => remove(name)}/>
                                                </Row>
                                            </Space>
                                        ))}
                                       <Form.Item>
                                            <Button type="dashed" onClick={() => add()} block icon={<PlusOutlined/>}>
                                                Click to add upload results
                                            </Button>
                                        </Form.Item> 
                                    </>
                                )}
                            </Form.List>
                            <center>    <Form.Item>
                                <Button type="primary" htmlType="submit">
                                    Save
                                </Button>
                            </Form.Item></center>
                        </Form>

                    </div>
                </div>
            </div>

            <p></p>
            <div className="ant-col ant-col-24">
                <div className="ant-card">
                    <div className="ant-card-body">
                        <center>Upload Results</center>
                        <div>
                            <h4>ReactJS Ant-Design Table Component</h4>
                            <Table dataSource={dataSource} columns={columns}/>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
}
export default ResultUpload
