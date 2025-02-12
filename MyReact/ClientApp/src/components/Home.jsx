import { useState } from 'react';
import { Button, Input, Select } from 'antd';
import { CheckOutlined } from '@ant-design/icons';

const Home = () => {

  const [loginAdd, setLoginAdd] = useState('123')
  const [mySelect, setMySelect] = useState('');
  const handleChangeMySelect = (value) => {
    console.log(value)
    setMySelect(value);
  };

  const [dataSelect, setDataSelect] = useState([
    {
      "value": "1",
      "text": "qwerty"
    },
    {
      "value": "2",
      "text": "asdfgh"
    },
  ]);

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
          width: 252, marginLeft: 10
        }}
        showSearch
        status="error"
        //defaultValue="2"
        value={mySelect}
        optionFilterProp="children"
        onChange={handleChangeMySelect}
        filterOption={(input, option) => option.children.toLowerCase().includes(input.toLowerCase())}
      >
        {dataSelect.map((z) => (
          <Option key={z.value}>{z.text}</Option>
        ))}
      </Select>
    </div>
  );
}
export default Home;
