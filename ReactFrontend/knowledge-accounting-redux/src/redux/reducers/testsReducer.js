import { ActionTypes } from '../actions/actionTypes/testActions';

const initialState = {
    testsList: [],
    selectedTest: {},
    isTestingStarted: false
}

export default function (state = initialState, action) {
    switch (action.type) {
        case ActionTypes.SET_TEST_LIST: {
            return {...state, testsList: action.payload}
        }
        case ActionTypes.TEST_SELECTED: {
            return { ...state, selectedTest: action.payload }
        }
        case ActionTypes.TESTING_STARTED: {
            return {
                ...state,
                selectedTest: action.payload,
                isTestingStarted: true
            }
        }
        case ActionTypes.TESTING_ENDED: {
            return {
                ...state,
                selectedTest: action.payload,
                isTestingStarted: false
            }
        }
        default:
            return state;
    }
}