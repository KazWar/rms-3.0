//* Router initialization
import { router } from '@/plugins'

/**
 * Navigates the user to the destination page
 * 
 * @param to - A valid route name
 */
export function Navigate (to:any):void {
    router.push({
            ...to
        }
    )
}

