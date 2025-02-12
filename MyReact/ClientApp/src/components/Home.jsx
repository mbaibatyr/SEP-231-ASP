import { useState } from 'react';
import { Button, Input, Select } from 'antd';
import { CheckOutlined } from '@ant-design/icons';

const Home = () => {

  const [loginAdd, setLoginAdd] = useState('123')
  const [mySelect, setMySelect] = useState('');
  const handleChangeMySelect = (value) => {
    setMySelect(value);
  };

  const MyClick = () => {
    setLoginAdd('hello step123')
  }

  return (
    <div>
      <h1>Hello, world!</h1>

      <Button
        type='primary'
        icon={<CheckOutlined />}
        // onClick={() => {
        //   alert('hello step')
        // }}
        onClick={MyClick}
      />

      <Input
        placeholder="Input login"
        value={loginAdd}
        onChange={(e) => setLoginAdd(e.target.value)}
        style={{
          width: 252, marginLeft: 137
        }}
      />

      <Select
        style={{
          width: 252, marginLeft: 145
        }}
        showSearch
        status="warning"
        //defaultValue="2"
        value={mySelect}
        optionFilterProp="children"
        onChange={handleChangeMySelect}
        filterOption={(input, option) => option.children.toLowerCase().includes(input.toLowerCase())}
      >
        <Option key='4'>BUSINESS ANALYST</Option>
        <Option key='2'>BUSINESS CUSTOMER</Option>
        <Option key='3'>CHANGE DEVELOPER</Option>
        <Option key='5'>DEVELOPER</Option>
        <Option key='6'>GUEST</Option>
      </Select>
    </div>
  );
}
export default Home;
