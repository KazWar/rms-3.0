import axios from '@/plugins/axios'
import { AxiosRequestConfig, AxiosResponse } from 'axios'

export const useBaseService = () => {
    /**
     * Base axios request, supplement with options.
     */ 
    const request = async (options?:AxiosRequestConfig):Promise<AxiosResponse<any, any> | undefined> => {
        const Options = { ...options }

        try {
            const response = await axios(Options)

            if (response.status === 200) {
                return response
            }
        } catch (error) {
            console.log(error)
        }
    }

    return {
        request
    }
}
    
    

