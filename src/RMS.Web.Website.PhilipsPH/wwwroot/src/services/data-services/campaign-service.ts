import { Campaign } from '@/common/models'
import { AxiosResponse } from 'axios'
import { useBaseService } from './base-service'

//* Implement base service class
export const useCampaignService = () => {
    const { request } = useBaseService()

    /**
     * Makes a GET call to the /Campaign API endpoint
     * 
     * @returns A RestSharp RestResponse object containing an array of Campaign type objects.
     */
    const GetCampaigns = async (locale:string):Promise<Campaign[] | undefined> => {
        //! Extract the other contents of errors, success, etc... for later use
        const options = {
            method:'get',
            url:'campaign',
            params:{
                locale:locale
            }
        }

        return await request(options).then((response:AxiosResponse | undefined) => {

            // Check if API call returned something
            if (typeof response === 'object'){
                return response.data.content.map((campaign:Campaign) => new Campaign(campaign))
            }

            // Otherwise return undefined
            return undefined
        })
    }

    return {
        GetCampaigns
    }
}
