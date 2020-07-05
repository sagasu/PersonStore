import React from 'react';
import { render } from '@testing-library/react';
import App from './App';
import Enzyme, { shallow } from 'enzyme';
import Adapter from 'enzyme-adapter-react-16';

Enzyme.configure({ adapter: new Adapter() });
let wrapper;

describe("Elements testing", () => {
  beforeEach(() => {
    wrapper = shallow(<App />);
  });

  test('renders Search button', () => {
    expect(wrapper.find('form').text()).toContain('Search');
  });

  test('render input with text', () => {
    expect(wrapper.find('#search-btn').text()).toBe('Search');
  });

  test('my empty test', () => {
    //also success
  });
  
});
